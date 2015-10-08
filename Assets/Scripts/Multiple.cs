using UnityEngine;
using System.Collections;

public class Multiple : MonoBehaviour {
	public GameObject Player;
	public GameObject multiball;
	public GameObject defaltImage;
	public float force ;


	void OnCollisionEnter2D(Collision2D col) {
		GameObject shootball1;
		GameObject shootball2;
		GameObject defaultTile1;
		if (col.gameObject.tag == "Player") {
			Debug.Log ("colide");
			shootball1 = Instantiate(multiball,new Vector2 (col.gameObject.transform.position.x-1,col.gameObject.transform.position.y+2), Quaternion.identity)as GameObject;
			shootball2 = Instantiate(multiball,new Vector2 (col.gameObject.transform.position.x+1,col.gameObject.transform.position.y+2), Quaternion.identity)as GameObject;
			shootball1.GetComponent<Rigidbody2D>().AddForce(transform.up*force, ForceMode2D.Force);
			shootball2.GetComponent<Rigidbody2D>().AddForce(transform.up*force, ForceMode2D.Force);

			defaultTile1 = Instantiate(defaltImage,new Vector2 (col.gameObject.transform.position.x,col.gameObject.transform.position.y-2), Quaternion.identity)as GameObject;
			defaultTile1.tag = "GTiles";
			defaultTile1.layer = LayerMask.NameToLayer ("Objects");
			defaultTile1.GetComponent<Tiles> ().reset ();
			Destroy(this.gameObject);

			
		}
	}


}
