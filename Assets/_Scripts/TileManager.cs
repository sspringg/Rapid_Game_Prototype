using UnityEngine;
using System.Collections;
public enum side{
	left,
	top,
	right
}
public class TileManager : MonoBehaviour {

	public GameObject currentTile;
	public GameObject[] TilePrefabs;
//	private side curSide = side.top;
	private int leftTotal, rightTotal, topTotal;
	// Use this for initialization
	void Start () {
		leftTotal = rightTotal = topTotal = 3;
		spawnTiles();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void spawnTiles(){
//		currentTile =  (GameObject)Instantiate(rightTilePrefab, currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
	}
}
