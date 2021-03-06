﻿using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	public bool IHateChangingTheTouchControlALotNowToDrag = false; //honestly, we changed from Drag-n-Drop to Click-n-Click then back, might as well make both of them to prevent hassle
	//true = Drag-n-Drop, false = Click-n-Click

	public Vector3 cameraPos;
	public bool seletion;

	public GameObject TileDefault;
	public GameObject Tile1;
	public GameObject Tile2;
	public GameObject Tile3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			//press down
			cameraPos = Camera.main.ScreenToWorldPoint (Input.mousePosition + new Vector3 (0, 0, 10));
			RaycastHit2D hit = Physics2D.Raycast (cameraPos, Vector2.zero);

			if (!seletion) {
				//if no tiles are currently selected
				if (hit.collider != null || hit.rigidbody || !hit.rigidbody.isKinematic) {
					if (hit.collider.gameObject.GetComponent<Tiles> ().active) {
						//tile is now currently selected
						if (IHateChangingTheTouchControlALotNowToDrag) {
							Makeo (cameraPos, hit.collider.gameObject);
						} else {
							hit.collider.gameObject.tag = "selecto";
						}
						
						seletion = true;
						return;
					}
				}
			}


			if (hit.collider != null) {
				if (!hit.collider.gameObject.GetComponent<Tiles> ().active) {
					//get rid of a placed tile
					Destroy (hit.collider.gameObject);
					return;
				}
			}

			if (!IHateChangingTheTouchControlALotNowToDrag){
			if (seletion) {
				if (hit.collider != null) {
					if (hit.collider.gameObject.tag != "selecto" &&
						hit.collider.gameObject.GetComponent<Tiles> ().active) {
						//change currently selected tile
						GameObject temp = GameObject.FindWithTag ("selecto");

						temp.tag = "UITile";
						hit.collider.gameObject.tag = "selecto";
					}
				} else {
					//placing selected tile
					Collider2D[] c2 = new Collider2D[2];
					float rad = 0.5f;

					//checking the radius if an object is nearby
					int i = Physics2D.OverlapCircleNonAlloc (new Vector2 (cameraPos.x, cameraPos.y), rad, c2);

					Debug.Log (i);
					if (i < 1) {
						//deselecting and placing selected tile
						GameObject temp = GameObject.FindWithTag ("selecto");

						Makeo (cameraPos, temp);

						temp.tag = "UITile";

						//if it was a special tile, adding new one
						if (temp.GetComponent<Tiles> ().theTileType != Tiles.TileType.TNORMAL) {

							temp = GameObject.FindGameObjectWithTag ("UI");
							temp.GetComponent<TileList> ().Shifto ();
							temp.GetComponent<TileList> ().Addo ();
						}
						return;
					}
				}
			}
			}//IHateChanging etcs

		}


		//draging code
		if (IHateChangingTheTouchControlALotNowToDrag) {
			if (Input.GetMouseButton (0)) {
				//drag
				if (seletion) {
					GameObject temp = GameObject.FindWithTag ("selecto");
					cameraPos = Camera.main.ScreenToWorldPoint (Input.mousePosition + new Vector3 (0, 0, 10));
					temp.transform.position = cameraPos;
				}
			} else if (Input.GetMouseButtonUp (0)) {
				//let go
				if (seletion) {
					seletion = false;

					//placing selected tile
					Collider2D[] c2 = new Collider2D[2];
					float rad = 0.5f;
					
					//checking the radius if an object is nearby
					int i = Physics2D.OverlapCircleNonAlloc (new Vector2 (cameraPos.x, cameraPos.y), rad, c2);
					
					Debug.Log (i);

					GameObject temp = GameObject.FindWithTag ("selecto");
					
					if (i < 2) {	
						cameraPos = Camera.main.ScreenToWorldPoint (Input.mousePosition + new Vector3 (0, 0, 10));
						temp.transform.position = cameraPos;
						temp.layer = LayerMask.NameToLayer ("Objects");

						switch(temp.GetComponent<Tiles>().theTileType) {
						case Tiles.TileType.TNORMAL:
							temp.tag = "GTiles";
							break;
						case Tiles.TileType.TTILE1:
							temp.tag = "GTiles";
							break;
						case Tiles.TileType.TTILE2:
							temp.tag = "GTilesMagnet";
							break;
						case Tiles.TileType.TTILE3:
							temp.tag = "GTiles";
							break;
						}

						temp.GetComponent<Tiles> ().reset ();


						if (temp.GetComponent<Tiles> ().theTileType != Tiles.TileType.TNORMAL) {

							temp = GameObject.FindGameObjectWithTag ("UI");
							temp.GetComponent<TileList> ().Shifto ();
							temp.GetComponent<TileList> ().Addo ();
						}
					}
					else {
						Destroy(temp.gameObject);
					}
					
				}
			}
		} //IHateEtc
	}

	private void Makeo (Vector3 pos, GameObject theTile) {
		//making and changing tags and layers
		GameObject temp;

		switch (theTile.GetComponent<Tiles>().theTileType) {
		case Tiles.TileType.TNORMAL:
			temp = Instantiate (TileDefault, pos, transform.rotation) as GameObject;
			temp.GetComponent<Renderer>().sortingOrder = 1;
			//temp.transform.Rotate(0,0,90);

			if(IHateChangingTheTouchControlALotNowToDrag) {
				temp.tag = "selecto";
			}
			else {
				temp.layer = LayerMask.NameToLayer ("Objects");
				temp.tag = "GTiles";
				temp.GetComponent<Tiles> ().reset ();
			}
			break;

		case Tiles.TileType.TTILE1:
			temp = Instantiate (Tile1, pos, transform.rotation) as GameObject;
			temp.GetComponent<Renderer>().sortingOrder = 1;
			//temp.transform.Rotate(0,0,90);
			if(IHateChangingTheTouchControlALotNowToDrag) {
				temp.tag = "selecto";
			}
			else {
				temp.layer = LayerMask.NameToLayer ("Objects");
				temp.tag = "GTiles";
				temp.GetComponent<Tiles> ().reset ();
			}
			break;
		case Tiles.TileType.TTILE2:
			temp = Instantiate (Tile2, pos, transform.rotation) as GameObject;
			temp.GetComponent<Renderer>().sortingOrder = 1;
			//temp.transform.Rotate(0,0,90);
			if(IHateChangingTheTouchControlALotNowToDrag) {
				temp.tag = "selecto";
			}
			else {
				temp.layer = LayerMask.NameToLayer ("Objects");
				temp.tag = "GTilesMagnet";
				temp.GetComponent<Tiles> ().reset ();
			}
			break;
		case Tiles.TileType.TTILE3:
			temp = Instantiate (Tile3, pos, transform.rotation) as GameObject;
			temp.GetComponent<Renderer>().sortingOrder = 1;
			//temp.transform.Rotate(0,0,90);
			if(IHateChangingTheTouchControlALotNowToDrag) {
				temp.tag = "selecto";
			}
			else {
				temp.layer = LayerMask.NameToLayer ("Objects");
				temp.tag = "GTiles";
				temp.GetComponent<Tiles> ().reset ();
			}
			break;
		}

		//then deselect
		if(!IHateChangingTheTouchControlALotNowToDrag) {
			seletion = false;
		}
	}
}
