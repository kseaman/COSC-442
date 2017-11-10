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
				}

				if(SceneManager.GetActiveScene ().name == "Defeat"){
					Analytics.CustomEvent ("Player lose", new Dictionary<string, object>{{"Player ID:", SystemInfo.deviceUniqueIdentifier},
						{"Timestamp:", System.DateTime.Now}});
				}
			}
			sceneName = SceneManager.GetActiveScene ().name;
		}
	}
}
