using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	bool magnet = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if (magnet) {
			GameObject temp = GameObject.FindGameObjectWithTag ("Player");

			Vector2 pos = new Vector2(temp.gameObject.transform.position.x,
			                          temp.gameObject.transform.position.y);

			this.GetComponent<Rigidbody2D>().AddForce(pos);
		}
	}
}
