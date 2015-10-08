using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileList : MonoBehaviour {

	public Transform UIParent;

	public GameObject Tile1;
	public GameObject Tile2;
	public GameObject Tile3;

	int RangeMax = 2;
	int listAmount = 0;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 1; i++) {
			spawnUITiles( (5.7f - i*2), -9.5f, i+1);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void spawnUITiles (float x, float y, int UINum) {
		GameObject temp;
		int rng = Random.Range (1, RangeMax+1);

		if (rng == 1) {
			temp = Instantiate (Tile1, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;

			temp.layer = LayerMask.NameToLayer("UI");
			temp.transform.parent = UIParent;
			temp.GetComponent<Tiles>().Set(rng, UINum);
		}
		if (rng == 2) {
			temp = Instantiate (Tile2, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;

			temp.layer = LayerMask.NameToLayer("UI");
			temp.transform.parent = UIParent;
			temp.GetComponent<Tiles>().Set(rng, UINum);
		}
//		if (rng == 3) {
//			temp = Instantiate (Tile3, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
//
//			temp.layer = LayerMask.NameToLayer("UI");
//			temp.transform.parent = UIParent;
//			temp.GetComponent<Tiles>().Set(rng, UINum);
//		}

		listAmount++;
	}

	public void Shifto () {
		//first locate that one then delete and shift down
		//all listorder--?

		GameObject[] go;
		
		go = GameObject.FindGameObjectsWithTag("UITile");
		foreach (GameObject obj in go) {
			Tiles sc = obj.GetComponent<Tiles> ();
			if (sc.listOrder == 1) {

				Destroy(obj.gameObject);
				listAmount--;
			}
			else if (sc.listOrder > 1) {
				sc.listOrder--;
				obj.transform.Translate(2, 0,0);
			}
		}
	}

	public void Addo () {
		spawnUITiles( (5.7f - listAmount*2), Camera.main.transform.position.y-9.5f, listAmount+1);
	}
}
