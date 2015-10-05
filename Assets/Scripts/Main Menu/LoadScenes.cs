using UnityEngine;
using System.Collections;

public class LoadScenes : MonoBehaviour {

	public void loadNextScene (int NextNum) {
		Application.LoadLevel (NextNum);
	}
	
	public void loadNextScene (string NextString) {
		Application.LoadLevel (NextString);
	}
}
