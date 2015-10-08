using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour {

	public bool magnet = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if (magnet) {
			GameObject temp = GameObject.FindGameObjectWithTag ("Player");

			Vector2 force = new Vector2((temp.gameObject.transform.position.x - this.transform.position.x),
			                    	    (temp.gameObject.transform.position.y - this.transform.position.y));

			this.GetComponent<Rigidbody2D>().AddRelativeForce(force);
		}
	}
}
