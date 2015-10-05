using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	int buttonHeight = Screen.height/ 8;
	int buttonWidth = Screen.width / 3;

	public Texture tart;
	public Texture Highscore;

	//Font fS;

	// Use this for initialization
	void Start () {
		//GUI.skin.font.fontSize = Screen.height/ 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 3, (Screen.height + buttonHeight) / 2,
		                          buttonWidth, buttonHeight ), tart) )
			Application.LoadLevel ("a");

		if (GUI.Button (new Rect (Screen.width / 3, (Screen.height + buttonHeight) / 2 + buttonHeight * 3 / 2,
		                          buttonWidth, buttonHeight ), "Highscore") )
			Application.LoadLevel ("Highscore");
	}
}
