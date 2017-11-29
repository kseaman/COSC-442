using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audioManager : MonoBehaviour {

	public AudioClip Sound;
	public AudioClip Sound2;

	private AudioSource source;

	private static GameObject Muter;
	public bool muted = false;


	string sceneName = "";

	void Awake () {
		DontDestroyOnLoad (this.gameObject);

		if (Muter == null) {
			Muter = this.gameObject;
		} else {
			DestroyObject (this.gameObject);
		}

		sceneName = SceneManager.GetActiveScene ().name;
	}

	// Use this for initialization
	void Start () {

		//background music
		source = GetComponent<AudioSource> ();
		source.enabled = true;
		source.clip = Sound;
		source.Play();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (sceneName != SceneManager.GetActiveScene ().name) {

			if(sceneName == "CutScene2"){
				source.Stop ();
				source.clip = Sound;
				source.Play ();
			}

			if (muted) {
				AudioListener.volume = 0.0f;
			} else {
				AudioListener.volume = 1.0f;
			}

			if (SceneManager.GetActiveScene ().name == "CutScene1") {
				source.Stop ();
			}

			if (SceneManager.GetActiveScene ().name == "CutScene2") {
				source.Stop ();
			}
				

			if (SceneManager.GetActiveScene ().name == "Story") {
				source.Stop ();
				source.clip = Sound2;
				source.Play ();
			}

			sceneName = SceneManager.GetActiveScene ().name;
		}
		
	}

	public void mute(){
		muted = !muted;
		if (muted) {
			AudioListener.volume = 0.0f;
		} else {
			AudioListener.volume = 1.0f;
		}
	}
}
