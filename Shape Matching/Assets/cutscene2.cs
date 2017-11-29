using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscene2 : MonoBehaviour {

	public Transform shapeulese;
	public Transform triangulara;

	public AudioClip Sound1;
	public AudioClip Sound2;
	public AudioClip Sound3;

	public bool trigger1 = false;
	public bool trigger2;
	public bool trigger3;

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

		if (!trigger2 && time > 4.5f) {
			source.Stop ();
			source.clip = Sound2;
			source.Play ();

			triangulara.gameObject.SetActive (false);

			trigger2 = true;
		}

		if (!trigger3 && time > 9) {
			source.Stop ();
			source.clip = Sound3;
			source.Play ();

			shapeulese.gameObject.SetActive (false);

			trigger3 = true;
		}

		if (time > 14) {
			SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
		}
		
	}
}
