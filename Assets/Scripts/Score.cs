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


	void OnGUI() {
//		GUI.Label (new Rect (Screen.width / 8, Screen.width / 8,
//		                     Screen.width / 2, Screen.width / 8), "points : " + score);


//        if (GUI.Button (new Rect (Screen.width / 8, Screen.width / 6,
//                             Screen.width / 2, Screen.width / 8), "save")) {
//            SaveLoadScore.AddSort(score);
//        }
	}

	public void AddCurrent() {
		SaveLoadScore.AddSort(score);
	}
}



//GameObject temp = GameObject.FindWithTag ("UI");
//temp.GetComponent<Score>().scoreAdd(100);