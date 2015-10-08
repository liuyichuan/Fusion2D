using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {

	public GameObject defaultTile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void attract() {
		//find all the coins and activate their attraction to the player
		GameObject[] go;
		
		go = GameObject.FindGameObjectsWithTag("Coin");
		foreach (GameObject obj in go) {
			Coin sc = obj.GetComponent<Coin> ();
			sc.magnet = true;
		}
		change ();
	}

	public void change() {
		//changing to a normal tile
		GameObject temp;

		temp = Instantiate(defaultTile,new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity)as GameObject;
		temp.tag = "GTiles";
		temp.layer = LayerMask.NameToLayer ("Objects");
		temp.GetComponent<Tiles> ().reset ();
		Destroy(this.gameObject);
	}
}
