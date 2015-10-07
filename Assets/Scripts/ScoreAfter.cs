using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreAfter : MonoBehaviour {

	public int scoreA = 0;
	
	Text text;
	
	// Use this for initialization
	void Start () {
		GameObject temp;
		temp = GameObject.FindGameObjectWithTag ("Score");

		scoreA = temp.GetComponent<Score> ().score;
		
		temp.GetComponent<Score> ().AddCurrent ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + scoreA;
	}
	
	void Awake() {
		text = GetComponent<Text> ();
	}
}