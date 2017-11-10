using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchSound : MonoBehaviour {

	public AudioClip Sound;

	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play(){
		source.enabled = true;
		source.PlayOneShot (Sound, 1f);
	}
}
