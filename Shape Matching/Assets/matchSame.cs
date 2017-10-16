using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchSame : MonoBehaviour {

	public bool collided = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		collided = true;
		if (other.tag == gameObject.tag) {
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
	}
}
