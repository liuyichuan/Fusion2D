using UnityEngine;
using System.Collections;

public class Despawning : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.transform.position.y - this.transform.position.y > 20) {
			Destroy(this.gameObject);
		}
	}
}
