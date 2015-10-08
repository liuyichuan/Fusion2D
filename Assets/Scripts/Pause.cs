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
				Time.timeScale = 0;
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
		leavepanel.SetActive(true);
		showpanel =true;	
		Time.timeScale = 0;
	}
	public void onResume(){
		leavepanel.SetActive (false);
		showpanel = false;
		Time.timeScale = 1;
	}
	public void restart()
	{
		leavepanel.SetActive (false);
		life.lifecount = 3;
		Application.LoadLevel (Application.loadedLevel);
	}
	public void Quit(){
		Application.Quit ();
	}     
	public void BacktoMenu(){
		Application.LoadLevel ("Main");
		showpanel =false;
		life.lifecount = 3;
	}


 	


}
