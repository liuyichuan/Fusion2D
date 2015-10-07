using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Score : MonoBehaviour {
	
	[SerializeField]
	public int score = 0;

	Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
	}

	void Awake() {
		text = GetComponent<Text> ();
	}


	public void AddCurrent() {
		SaveLoadScore.AddSort(score);
	}

}