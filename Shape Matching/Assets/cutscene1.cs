using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscene1 : MonoBehaviour {

	public Transform shapeulese;
	public Transform triangulara;

	public AudioClip Sound1;
	public AudioClip Sound2;
	public AudioClip Sound3;
	public AudioClip Sound4;
	public AudioClip Sound5;
	public AudioClip Sound6;
	public AudioClip Sound7;
	public AudioClip Sound8;
	public AudioClip Sound9;
	public AudioClip Sound10;
	public AudioClip Sound11;
	public AudioClip Sound12;
	public AudioClip Sound13;
	public AudioClip Sound14;
	public AudioClip Sound15;
	public AudioClip Sound16;

	public bool trigger1;
	public bool trigger2;
	public bool trigger3;
	public bool trigger4;
	public bool trigger5;
	public bool trigger6;
	public bool trigger7;
	public bool trigger8;
	public bool trigger9;
	public bool trigger10;
	public bool trigger11;
	public bool trigger12;
	public bool trigger13;
	public bool trigger14;
	public bool trigger15;
	public bool trigger16;

	public bool anim1;

	private AudioSource source;

	public float time = 0.0f;

	public string sceneName;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		source.enabled = true;
		source.clip = Sound1;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (!trigger1 && time > 1) {
			source.Play ();
			trigger1 = true;
		}

		if(!anim1 && time > 15){
			shapeulese.position = new Vector3 (0, 0, 0);
			shapeulese.localScale = new Vector3 (3, 3, 1);
			anim1 = true;
		}

		if (!trigger2 && time > 42) {
			source.Stop ();
			source.clip = Sound2;
			source.Play ();

			shapeulese.position = new Vector3 (-3, -3, 0);
			shapeulese.localScale = new Vector3 (1, 1, 1);

			triangulara.position = new Vector3 (-6.75f, -3, 0);

			trigger2 = true;
		}

		if (!trigger3 && time > 44) {
			source.Stop ();
			source.clip = Sound3;
			source.Play ();
			trigger3 = true;
		}

		if (!trigger4 && time > 48) {
			source.Stop ();
			source.clip = Sound4;
			source.Play ();
			trigger4 = true;
		}

		if (!trigger5 && time > 50) {
			source.Stop ();
			source.clip = Sound5;
			source.Play ();
			trigger5 = true;
		}

		if (!trigger6 && time > 51) {
			source.Stop ();
			source.clip = Sound6;
			source.Play ();
			trigger6 = true;
		}

		if (!trigger7 && time > 55) {
			source.Stop ();
			source.clip = Sound7;
			source.Play ();
			trigger7 = true;
		}

		if (!trigger8 && time > 58) {
			source.Stop ();
			source.clip = Sound8;
			source.Play ();
			trigger8 = true;
		}

		if (!trigger9 && time > 62.5f) {
			source.Stop ();
			source.clip = Sound9;
			source.Play ();
			trigger9 = true;
		}

		if (!trigger10 && time > 65) {
			source.Stop ();
			source.clip = Sound10;
			source.Play ();
			trigger10 = true;
		}

		if (!trigger11 && time > 68) {
			source.Stop ();
			source.clip = Sound11;
			source.Play ();

			shapeulese.position = new Vector3 (4, -3, 0);

			trigger11 = true;
		}

		if (!trigger12 && time > 72.5f) {
			source.Stop ();
			source.clip = Sound12;
			source.Play ();

			triangulara.position = new Vector3 (0, -3, 0);

			trigger12 = true;
		}

		if (!trigger13 && time > 74.5f) {
			source.Stop ();
			source.clip = Sound13;
			source.Play ();
			trigger13 = true;
		}

		if (!trigger14 && time > 76) {
			source.Stop ();
			source.clip = Sound14;
			source.Play ();
			trigger14 = true;
		}

		if (!trigger15 && time > 79) {
			source.Stop ();
			source.clip = Sound15;
			source.Play ();
			trigger15 = true;
		}

		if (!trigger16 && time > 83) {
			source.Stop ();
			source.clip = Sound16;
			source.Play ();
			trigger16 = true;
		}

		if (time > 85) {
			SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
		}
	}
}
