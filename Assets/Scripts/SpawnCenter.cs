using UnityEngine;
using System.Collections;

public class SpawnCenter : MonoBehaviour {

	public GameObject coin;
	public GameObject hole;
	public GameObject obstacle;

	public GameObject zone1;
	public GameObject zone2;
	public GameObject zoneFinal;
	
	public GameObject zoneBreak;


	int itemSpawnPosY = 0;
	int frequncyDown =  0;


	//for background
	int areaCount = 1;
	public int areaCountMax = 4;
	public int areaHeight = 25;
	int zoneCount = 0;
	public int zoneCountMax = 6;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 2; i++) {
			Instantiate (zone1, new Vector3 (0, i*areaHeight, 1), Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {

		if (Camera.main.transform.position.y > ((zoneCount * areaCountMax) + areaCount) * areaHeight) {
			areaCount++;
			if (areaCount > areaCountMax && zoneCount < zoneCountMax) {
				areaCount = 1;
				zoneCount++;
			}
			spawnBackground ();
		}
		if (Camera.main.transform.position.y > itemSpawnPosY)
			spawnItems ();
	}

	
	void spawnBackground () {
		//the breaks between each zones
		//to transition between zone nicely
		if (areaCount == 1) {
			if (zoneCount == 1) //between 1 and 2
				Instantiate (zoneBreak, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
		else if (zoneCount == 2) //between 2 and 3
				Instantiate (zoneBreak, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
		else if (zoneCount == 3) //between 3 and 4
				Instantiate (zoneBreak, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
		else if (zoneCount == 4) //between 4 and 5
				Instantiate (zoneBreak, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
		else if (zoneCount == 5) //between 5 and 6
				Instantiate (zoneBreak, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
			else if (zoneCount == 6) //between 6 and (7 or endless)
				Instantiate (zone2, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
		}

		//the background of each zones
		else {
			if (zoneCount == 0) //zone 1
				Instantiate (zone1, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
		else if (zoneCount == 1) //zone 2
				Instantiate (zone2, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
		else if (zoneCount == 2) //zone 3
				Instantiate (zone2, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
		else if (zoneCount == 3) //zone 4
				Instantiate (zone2, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
		else if (zoneCount == 4) //zone 5
				Instantiate (zone2, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
		else if (zoneCount == 5) //zone 6
				Instantiate (zone1, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
			else //zone 7 or endless
				Instantiate (zoneFinal, new Vector3 (0, ((zoneCount * areaCountMax) + areaCount) * areaHeight, 1), Quaternion.identity);
		}
	}

	void spawnItems () {
		int rng = Random.Range (1, 11-zoneCount); //10, 2 coins, 1 hole, 1 obstacle
	
		if (rng <= 0 || rng >= 7-zoneCount) {
			//frequence increase as you increase zone
			//frequncyDown is to reduce chances of holes or obstacles to spawn too often

			float x = Random.Range (-5, 5);

			if (rng == 0 || rng - frequncyDown == 7-zoneCount) { //coins, spawn at zone 1+
				Instantiate (coin, new Vector3 (x, itemSpawnPosY + 15, 0), Quaternion.identity);
				frequncyDown = 0;
			}
			else if (rng - frequncyDown == 8-zoneCount && zoneCount > 0) { //obstacle, spawn at zone 2+
				Instantiate (obstacle, new Vector3 (x, itemSpawnPosY + 15, 0), Quaternion.identity);
				frequncyDown++;
			}
			else if (rng - frequncyDown == 9-zoneCount && zoneCount > 1) { //hole, spawn at zone 3+
				Instantiate (hole, new Vector3 (x, itemSpawnPosY + 15, 0), Quaternion.identity);
				frequncyDown++;
			}
		}
		itemSpawnPosY++;
	}
}