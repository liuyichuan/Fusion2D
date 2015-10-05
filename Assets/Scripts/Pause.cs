using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public GameObject pauseButton, resumeButton,leavepanel;
	bool showpanel = false;
	// Use this for initialization
	void Start () {
		onResume ();
		showpanel = false;
	
	}

	void Update(){
		if (Input.GetKeyUp (KeyCode.Escape)) {

			if(!showpanel){
				leavepanel.SetActive(true);
				onPause();
				showpanel =true;
			}
			else if(showpanel){
				leavepanel.SetActive(false);
				onResume();
				showpanel = false;
			}


		}
	}
	public void onPause(){
		pauseButton.SetActive (false);
		resumeButton.SetActive (true);
		Time.timeScale = 0;
	}
	public void onResume(){
		pauseButton.SetActive (true);
		resumeButton.SetActive (false);
		Time.timeScale = 1;
	}
	public void Quit(){
		Application.Quit ();
	}     
 	


}
