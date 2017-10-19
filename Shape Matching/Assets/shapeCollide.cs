using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shapeCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Match Circle" || other.tag == "Match Triangle" || other.tag == "Match Square" || other.tag == "Match Pentagon" || other.tag == "Match Hexagon") {
			SceneManager.LoadScene ("Defeat", LoadSceneMode.Single);
		}
	}
}
