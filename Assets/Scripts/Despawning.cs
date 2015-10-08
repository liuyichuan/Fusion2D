using UnityEngine;
using System.Collections;

public class Despawning : MonoBehaviour {

	public int despawnLength = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.transform.position.y - this.transform.position.y > despawnLength) {
			Destroy(this.gameObject);
		}
	}
}
