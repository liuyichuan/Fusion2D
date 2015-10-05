using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float currentHeight = 0;
	public float highestHeight = 0;
	public float Respawnpoint  =0;
	public GameObject explosion;
	public GameObject Player;

	float dif = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//this.gameObject.transform.Translate(0, 2*Time.deltaTime, 0);

		currentHeight = this.gameObject.transform.position.y;

		if (currentHeight > highestHeight+dif) {
			float differ = currentHeight - highestHeight-dif;
			Camera.main.transform.Translate(0, differ, 0);

			highestHeight += differ;
		}
		
		if (Camera.main.transform.position.y - this.transform.position.y > 13) {
			RespawnBall();
			Destroy (this.gameObject);
			life.lifecount-=1;
		}


		if (this.transform.position.x > 7)
			this.transform.Translate( new Vector3 (-this.transform.position.x - 7 ,0,0) );

		if (this.transform.position.x < -7)
			this.transform.Translate( new Vector3 (-this.transform.position.x + 7 ,0,0) );
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
			life.lifecount-=1;
			RespawnBall();
		}
	}

	void RespawnBall(){

			
			Instantiate (Player, new Vector3 (0, Camera.main.transform.position.y + Respawnpoint + dif, 0), Quaternion.identity);
			//this.gameObject.transform.position =new Vector3(0,Camera.main.transform.position.y+Respawnpoint,0);

	}
}
