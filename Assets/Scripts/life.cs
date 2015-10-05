using UnityEngine;
using System.Collections;

public class life : MonoBehaviour {
	public Sprite life3;
	public Sprite life2;
	public Sprite life1;
	public GameObject losepanel;
	public GameObject leavepanel;

	static public int lifecount = 3;
	private SpriteRenderer spriteRenderer; 

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (lifecount) {
		case 3:
			spriteRenderer.sprite = life3;
			break;
		case 2:
			spriteRenderer.sprite = life2;
			break;
		case 1:
			spriteRenderer.sprite  = life1;
			break;
		case 0:
			spriteRenderer.sprite  = null;
			Time.timeScale =0;
			losepanel.SetActive(true);
			break;
		}

	
	}
	public void restart()
	{
		losepanel.SetActive (false);
		leavepanel.SetActive (false);
		lifecount = 3;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void backmenu()
	{
		losepanel.SetActive (false);
		leavepanel.SetActive (false);
		lifecount = 3;
		Application.LoadLevel ("Main");
	}



}
