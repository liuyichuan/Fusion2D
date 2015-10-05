using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	int buttonHeight = Screen.height/ 12;
	int buttonWidth = Screen.width / 3;

	public Texture tart;
	public Texture Highscore;

	GUIStyle fS;

	// Use this for initialization
	void Start () {
		fS = new GUIStyle ();
		fS.fontSize = Screen.height/ 10;
		//fS.skin.button.fontSize = Screen.height/ 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {

		if (GUI.Button (new Rect (Screen.width / 3, (Screen.height) / 2,
		                          buttonWidth, buttonHeight ), tart, fS) )
			Application.LoadLevel ("a");

		if (GUI.Button (new Rect (Screen.width / 3, (Screen.height + buttonHeight) / 2 + buttonHeight * 3 / 2,
		                          buttonWidth, buttonHeight ), "Highscore") )
			Application.LoadLevel ("Highscore");
	}
}
