using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

	int buttonHeight = Screen.height/ 24;
	int buttonWidth = Screen.width / 4;
	
	Text text;
	
	// Update is called once per frame
	void Update () {

	}
	
	void Awake() {
		text = GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
		SaveLoadScore.Load();
		//show score in text
		text.text += "Personal Top 10 \n\n";
		
		int i = 1;
		
		foreach(int s in SaveLoadScore.savedScores) {
			if (i < 11){
				text.text += i + ": " + s + "\n\n";
				i++;
			}
		}
		for (; i < 11; i++) {
			text.text += i + ": --- \n\n";
		}
	}
	
}
