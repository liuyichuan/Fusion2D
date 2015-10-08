using UnityEngine;
using System.Collections;

public class multipleball : MonoBehaviour {


	public GameObject explosion;
	
	float dif = 10;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Camera.main.transform.position.y - this.transform.position.y > 13) {

			Destroy (this.gameObject);
	
		}	
		
		}
	
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Coin") {
			Destroy (col.gameObject);
			
			GameObject[] temp;
			temp = GameObject.FindGameObjectsWithTag ("Score");
			
			foreach (GameObject obj in temp) {
				obj.GetComponent<Score>().score += 100;
			}
		}
		if (col.gameObject.tag == "Hole") {
			
			Instantiate(explosion,new Vector3 (col.gameObject.transform.position.x,col.gameObject.transform.position.y,col.gameObject.transform.position.z), Quaternion.identity);
			Destroy(this.gameObject);
			
		}
	}
	

}
