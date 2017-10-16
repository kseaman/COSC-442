using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		GUI.contentColor = Color.black;
		GUI.Label (new Rect (Screen.width/2-50, Screen.height/2-25, 100, 50), "Credits:\nKarn Seaman", centeredStyle);
	}
}
