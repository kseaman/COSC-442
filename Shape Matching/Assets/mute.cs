using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mute : MonoBehaviour {

	audioManager manager = null;
	bool muted = false;


	// Use this for initialization
	void Start () {
		manager = GameObject.FindWithTag ("StaticObject").GetComponent<audioManager> ();
		muted = manager.muted;
		this.gameObject.transform.GetChild (1).GetComponent<Renderer> ().enabled = muted;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp(){
		muted = !muted;
		manager.mute ();
		this.gameObject.transform.GetChild (1).GetComponent<Renderer> ().enabled = muted;
	}
}
