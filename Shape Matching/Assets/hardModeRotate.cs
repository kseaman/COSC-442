using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hardModeRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//check if it's hard mode
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "Hard") {
			this.gameObject.transform.GetChild (0).eulerAngles = new Vector3 (0, 0, Random.Range(0, 360));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
