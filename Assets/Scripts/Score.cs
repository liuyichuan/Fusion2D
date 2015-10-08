using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public int score = 0;

	Text text;
	
	// Update is called once per frame
	void Update () {
		//show score in text
		text.text = "Score: " + score;
	}

	void Awake() {
		text = GetComponent<Text> ();
	}
}