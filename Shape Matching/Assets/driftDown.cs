using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class driftDown : MonoBehaviour {

	public bool storyMode = false;
	public bool touchInput = false;
	public bool mouseInput = false;

	// Use this for initialization
	void Start () {
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "Story") {
			storyMode = true;
			this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.05f;
		}
	}
	
	// Update is called once per frame
	void Update () {

		// if there's no mouse input, check for touch input
		if (storyMode && !mouseInput) {
			if (Input.touchCount == 1) {
				this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
			} else {
				this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.05f;
			}
		}

		if (storyMode) {
			if (mouseInput) {
				if (!Input.GetMouseButton (0)) {
					mouseInput = false;
					this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.05f;
				}
			}
		}
		
	}

	void OnMouseDown()
	{
		//if there's no touch input, check for mouse input
		if (storyMode && !touchInput) {
			this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
			mouseInput = true;
		}
	}
}
