using UnityEngine;
using System.Collections;

public class Tiles : MonoBehaviour {

	public enum TileType{
		TNORMAL = 0,
		TTILE1,
		TTILE2,
		TTILE3
	};
	
	public bool active = false;
	public TileType theTileType = TileType.TNORMAL;

	public int listOrder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (listOrder == 1)
			active = true;
	}

	public void Set (int typeNum, int listNum) {
		switch (typeNum) {
		case 0:
			this.theTileType = TileType.TNORMAL;
			break;
		case 1:
			this.theTileType = TileType.TTILE1;
			break;
		case 2:
			this.theTileType = TileType.TTILE2;
			break;
		case 3:
			this.theTileType = TileType.TTILE3;
			break;
		}

		listOrder = listNum;
	}

	public void reset() {
		listOrder = 0;
		active = false;
	}
}
