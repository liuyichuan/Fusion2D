using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class ScoreAfter : MonoBehaviour {
	
	[SerializeField]
	public int scoreA = 0;
	
	Text text;
	
	// Use this for initialization
	void Start () {
		//to find the current score of the game
		GameObject temp;
		temp = GameObject.FindGameObjectWithTag ("Score");

		scoreA = temp.GetComponent<Score> ().score;

		AddCurrent ();
	}
	
	// Update is called once per frame
	void Update () {
		//show in text
		text.text = "Score: " + scoreA;
	}
	
	void Awake() {
		text = GetComponent<Text> ();
	}

	public void AddCurrent() {
		//saving the score
		SaveLoadScore.AddSort(scoreA);
	}
}