using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class donotdestroy : MonoBehaviour {

	private static GameObject thisObject;


	void Awake () {
		DontDestroyOnLoad (this.gameObject);

		if (thisObject == null) {
			thisObject = this.gameObject;
		} else {
			DestroyObject (this.gameObject);
		}
			
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "Credits") {
			DestroyObject (this.gameObject);
		}
	}
}
