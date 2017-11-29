using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsText : MonoBehaviour {

	GUIStyle style = new GUIStyle();

	// Use this for initialization
	void Start () {
		style.fontSize = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		GUI.contentColor = Color.black;
		GUI.Label (new Rect (Screen.width/2-500, Screen.height/2-25, 1000, 200), "Credits\n " +
			"Characters, UI: Karn Seaman\n" +
			"Background: Village by Gustavo Rezende\n" +
			"SFX: Single Shot SFX Pack by Casual Game Sounds \n" +
			"Music: Calm Background Music, Heroic Background Music by Bitsalive Game Studios", centeredStyle);
	}
}
