using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchSame : MonoBehaviour {

	public bool collided = false;
	public bool reported = false;

	public float timecollided = 0f;

	public matchSound matchScript;

	// Use this for initialization
	void Start () {
		matchScript = Camera.main.GetComponent <matchSound>();
	}
	
	// Update is called once per frame
	void Update () {
		if (collided) {
			timecollided += Time.deltaTime;
		} else {
			timecollided = 0f;
		}
		if(timecollided >= 1.25f && !reported){
			GameObject.FindWithTag ("StaticObject").GetComponent<SceneAnalyzer> ().reportError(gameObject.tag, GetClosestObject().tag);
			reported = true;
		}
		
	}

	void OnTriggerEnter2D(Collider2D other){
		collided = true;
		if (other.tag == gameObject.tag) {
			matchScript.Play ();
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		collided = false;
		reported = false;
	}

	public GameObject GetClosestObject(){

		GameObject closest = null;
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject> ();
		foreach(GameObject obj in allObjects){
			if (obj.tag != "Untagged" && obj.activeSelf) {
				if (closest == null) {
					closest = obj;
				}
				if(Vector3.Distance(transform.position, obj.transform.position) <= Vector3.Distance(transform.position, closest.transform.position)){
					closest = obj;
				}
			}
		}
		return(closest);
	}
}
