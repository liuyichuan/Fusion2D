using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

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
//		#if UNITY_ANDROID
//		{
//			if (TouchPhase == TouchPhase.Began) {
//				//press down
//				cameraPos = Camera.main.ScreenToWorldPoint (Input.mousePosition + new Vector3 (0, 0, 10));
//				RaycastHit2D hit = Physics2D.Raycast (cameraPos, Vector2.zero);
//			
//				if (hit.collider != null || hit.rigidbody || !hit.rigidbody.isKinematic) {
//					if (hit.collider.gameObject.GetComponent<Tiles> ().active) {
//						starto (cameraPos, hit.collider.gameObject);
//					}
//				}
//			
//			} else if (TouchPhase == TouchPhase.Moved) {
//				//drag
//				if (dragin) {
//					GameObject temp = GameObject.FindWithTag ("draggin");
//					cameraPos = Camera.main.ScreenToWorldPoint (Input.mousePosition + new Vector3 (0, 0, 10));
//					temp.transform.position = cameraPos;
//				}
//			} else if (TouchPhase == TouchPhase.Ended) {
//				//let go
//				if (dragin) {
//					GameObject temp = GameObject.FindWithTag ("draggin");
//					cameraPos = Camera.main.ScreenToWorldPoint (Input.mousePosition + new Vector3 (0, 0, 10));
//					temp.transform.position = cameraPos;
//					temp.layer = LayerMask.NameToLayer ("Objects");
//					temp.tag = "GTiles";
//					temp.GetComponent<Tiles> ().reset ();
//				
//					dragin = false;
//				
//					if (temp.GetComponent<Tiles> ().theTileType != Tiles.TileType.TNORMAL) {
//					
//						temp = GameObject.FindGameObjectWithTag ("UI");
//						temp.GetComponent<TileList> ().Shifto ();
//						temp.GetComponent<TileList> ().Addo ();
//					}
//				}
//			}
//		}
//		#endif

		if (Input.GetMouseButtonDown (0)) {
			//press down
			cameraPos = Camera.main.ScreenToWorldPoint (Input.mousePosition + new Vector3 (0, 0, 10));

			if (!seletion) {
				RaycastHit2D hit = Physics2D.Raycast (cameraPos, Vector2.zero);

				if (hit.collider != null || hit.rigidbody || !hit.rigidbody.isKinematic) {
					if (hit.collider.gameObject.GetComponent<Tiles> ().active) {
						hit.collider.gameObject.tag = "selecto";
						
						seletion = true;
					}
				}
				return;
			}


			if (seletion) {
				Collider2D[] c2 = new Collider2D[2];
				float rad = 0.5f;

				int i = Physics2D.OverlapCircleNonAlloc (new Vector2 (cameraPos.x, cameraPos.y), rad, c2);

				Debug.Log(i);
				if (i < 1) {

					GameObject temp = GameObject.FindWithTag ("selecto");

					makeo(cameraPos, temp);

					temp.tag = "UITile";

					if (temp.GetComponent<Tiles>().theTileType != Tiles.TileType.TNORMAL) {
						temp = GameObject.FindGameObjectWithTag ("UI");
						temp.GetComponent<TileList> ().Shifto ();
						temp.GetComponent<TileList> ().Addo ();
					}
					return;
				}
			}
		}




		//draging code
//			else if (Input.GetMouseButton (0)) {
//				//drag
//				if (dragin) {
//					GameObject temp = GameObject.FindWithTag ("draggin");
//					cameraPos = Camera.main.ScreenToWorldPoint (Input.mousePosition + new Vector3 (0, 0, 10));
//					temp.transform.position = cameraPos;
//				}
//			}
//			else if (Input.GetMouseButtonUp (0)) {
//				//let go
//				if (dragin) {
//					GameObject temp = GameObject.FindWithTag ("draggin");
//					cameraPos = Camera.main.ScreenToWorldPoint (Input.mousePosition + new Vector3 (0, 0, 10));
//					temp.transform.position = cameraPos;
//					temp.layer = LayerMask.NameToLayer ("Objects");
//					temp.tag = "GTiles";
//					temp.GetComponent<Tiles> ().reset ();
//
//					dragin = false;
//
//					if (temp.GetComponent<Tiles> ().theTileType != Tiles.TileType.TNORMAL) {
//
//						temp = GameObject.FindGameObjectWithTag ("UI");
//						temp.GetComponent<TileList> ().Shifto ();
//						temp.GetComponent<TileList> ().Addo ();
//					}
//				}
//			}

	}

	private void makeo (Vector3 pos, GameObject theTile) {
		GameObject temp;

		switch (theTile.GetComponent<Tiles>().theTileType) {
		case Tiles.TileType.TNORMAL:
			temp = Instantiate (TileDefault, pos, transform.rotation) as GameObject;
			temp.tag = "GTiles";
			temp.layer = LayerMask.NameToLayer ("Objects");
			temp.GetComponent<Tiles> ().reset ();
			break;

		case Tiles.TileType.TTILE1:
			temp = Instantiate (Tile1, pos, transform.rotation) as GameObject;
			temp.tag = "GTiles";
			temp.layer = LayerMask.NameToLayer ("Objects");
			temp.GetComponent<Tiles> ().reset ();
			break;
		case Tiles.TileType.TTILE2:
			temp = Instantiate (Tile2, pos, transform.rotation) as GameObject;
			temp.tag = "GTiles";
			temp.layer = LayerMask.NameToLayer ("Objects");
			temp.GetComponent<Tiles> ().reset ();
			break;
		case Tiles.TileType.TTILE3:
			temp = Instantiate (Tile3, pos, transform.rotation) as GameObject;
			temp.tag = "GTiles";
			temp.layer = LayerMask.NameToLayer ("Objects");
			temp.GetComponent<Tiles> ().reset ();
			break;
		}
		
		seletion = false;

	}

//	private bool checko (Vector3 pos) {
//		Collider2D[] c2 = new Collider2D[2];
//		if (Physics2D.OverlapCircleNonAlloc (new Vector2 (pos.x, pos.y), 5, c2, LayerMask.NameToLayer("Objects") > 0))
//			return true;
//		else
//			return false;
//	}
}
