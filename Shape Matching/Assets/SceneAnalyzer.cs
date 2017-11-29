using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class SceneAnalyzer : MonoBehaviour {

	private static GameObject Analizer;
	//public int testint = 1;
	int setSceneNum = 0;
	string sceneName;

	public int[,] errortracker = new int[9,9];
	public int reportnum = 0;

	public bool challengeMode = false;
	bool[] wintracker = new bool[20];
	public float finScore = 0.0f;

	int sceneNum(){
		if (SceneManager.GetActiveScene ().name == "Easy") {
			return 1;
		} else if (SceneManager.GetActiveScene ().name == "Medium") {
			return 2;
		} else if (SceneManager.GetActiveScene ().name == "Hard") {
			return 3;
		} else if (SceneManager.GetActiveScene ().name == "Story") {
			return 4;
		} else {
			return setSceneNum;
		}
	}

	void Awake () {
		DontDestroyOnLoad (this.gameObject);

		if (Analizer == null) {
			Analizer = this.gameObject;
		} else {
			DestroyObject (this.gameObject);
		}

		sceneName = SceneManager.GetActiveScene ().name;
	}

	// Use this for initialization
	void Start () {

		//set up the win tracker, every second entry is true
		bool setupBool = false;
		for(int i = 0; i<20; i++){
			wintracker [i] = setupBool;
			setupBool = !setupBool;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		//check if people are moving to higher or lower levels
		if (sceneName != SceneManager.GetActiveScene ().name) {
			if(SceneManager.GetActiveScene().name != "Main Menu"){
				
				//if the new scene is a higher level
				if (setSceneNum < sceneNum ()) {
					Analytics.CustomEvent ("Level Change", new Dictionary<string, object>{{"Increase from:", setSceneNum}, {"Increase to:", sceneNum()}});
				} 

				else if (setSceneNum == sceneNum ()) {
					//do nothing
				} 

				//if the new scene is a lower level
				else if (setSceneNum > sceneNum ()) {
					Analytics.CustomEvent ("Level Change", new Dictionary<string, object>{{"Decrease from:", setSceneNum}, {"Decrease to:", sceneNum()}});
				}
				setSceneNum = sceneNum ();

				//check if the player won or lost
				if(SceneManager.GetActiveScene ().name == "Victory"){
					Analytics.CustomEvent ("Player win", new Dictionary<string, object>{{"Player ID:", SystemInfo.deviceUniqueIdentifier}, 
						{"Timestamp:", System.DateTime.Now}});
					updateRecord (true);
				}

				if(SceneManager.GetActiveScene ().name == "Defeat"){
					Analytics.CustomEvent ("Player lose", new Dictionary<string, object>{{"Player ID:", SystemInfo.deviceUniqueIdentifier},
						{"Timestamp:", System.DateTime.Now}});
					updateRecord (false);
				}
					
			}
			sceneName = SceneManager.GetActiveScene ().name;
		}
	}

	//update the win tracker, true is a win
	void updateRecord(bool win){
		float endValue = 2.0f;
		finScore = 0f;
		for(int i = 0; i< wintracker.Length - 1; i++){
			wintracker[wintracker.Length - 1 - i] = wintracker[wintracker.Length - 2 - i];
		}
		wintracker [0] = win;

		foreach(bool gameWon in wintracker){
			if (gameWon) {
				finScore += endValue;
			} else {
				finScore -= endValue;
			}
			endValue -= 0.1f;
		}
		if (finScore > 7.0f) {
			challengeMode = true;
		} else {
			challengeMode = false;
		}
	}

	public void reportError(string shape1, string shape2){
		int num1 = -1;
		int num2 = -1;
		if (shape1 == "Match Circle") {
			num1 = 0;
		}else if(shape1=="Match Triangle"){
			num1 = 1;
		}else if(shape1=="Match Square"){
			num1 = 2;
		}else if(shape1=="Match Pentagon"){
			num1 = 3;
		}else if(shape1=="Match Hexagon"){
			num1 = 4;
		}else if(shape1=="Match Trapezoid"){
			num1 = 5;
		}else if(shape1=="Match Hourglass"){
			num1 = 6;
		}else if(shape1=="Match Star"){
			num1 = 7;
		}else if(shape1=="Match Moon"){
			num1 = 8;
		}

		if (shape2 == "Match Circle") {
			num2 = 0;
		}else if(shape2=="Match Triangle"){
			num2 = 1;
		}else if(shape2=="Match Square"){
			num2 = 2;
		}else if(shape2=="Match Pentagon"){
			num2 = 3;
		}else if(shape2=="Match Hexagon"){
			num2 = 4;
		}else if(shape2=="Match Trapezoid"){
			num2 = 5;
		}else if(shape2=="Match Hourglass"){
			num2 = 6;
		}else if(shape2=="Match Star"){
			num2 = 7;
		}else if(shape2=="Match Moon"){
			num2 = 8;
		}

		reportnum ++;
		errortracker[num1, num2] ++;
	}
}
