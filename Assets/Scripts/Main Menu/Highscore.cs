using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Highscore : MonoBehaviour {

	int buttonHeight = Screen.height/ 24;
	int buttonWidth = Screen.width / 4;

	public Vector2 scrollPosition;

	// Use this for initialization
	void Start () {
		SaveLoadScore.Load();
	}


	void OnGUI() {
		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height - buttonHeight * 3));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();


		GUILayout.Box("Personal Top 10 " + SaveLoadScore.savedScores.Count,GUILayout.MinWidth(buttonWidth),GUILayout.MinHeight(buttonHeight));
		GUILayout.Space(Screen.height/ 24);

		int i = 1;

		foreach(int s in SaveLoadScore.savedScores) {
			if (i < 11){
				GUILayout.Box(i + ": " + s,GUILayout.MinWidth(buttonWidth),GUILayout.MinHeight(buttonHeight));
				GUILayout.Space(Screen.height/ 48);
				i++;
			}
		}
		for (; i < 11; i++) {
				GUILayout.Box(i + ": ---",GUILayout.MinWidth(buttonWidth),GUILayout.MinHeight(buttonHeight));
			GUILayout.Space(Screen.height/ 48);
		}


		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

		if (GUI.Button (new Rect ((Screen.width - buttonWidth) / 2, Screen.height - buttonHeight*2,
		                          buttonWidth, buttonHeight ), "Back") )
			Application.LoadLevel ("Main");
	}
}
