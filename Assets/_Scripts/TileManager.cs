using UnityEngine;
using System.Collections;
public enum side{
	left,
	top,
	right
}
public class TileManager : MonoBehaviour {
	public static TileManager S;
	public GameObject currentTile;
	public GameObject[] TilePrefabs;
	public side curSide = side.top;
	// Use this for initialization
	void Start () {
		S = this;
		//spawn 2 right, 1 top, 2 left, 1 top, 2 right
		curSide = side.top;
		//2 right
		currentTile =  (GameObject)Instantiate(TilePrefabs[2], currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
		currentTile =  (GameObject)Instantiate(TilePrefabs[2], currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
		//1 up
		currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
		//2 left
		currentTile =  (GameObject)Instantiate(TilePrefabs[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
		currentTile =  (GameObject)Instantiate(TilePrefabs[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
		//1 up
		currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
		//2 right
		currentTile =  (GameObject)Instantiate(TilePrefabs[2], currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
		currentTile =  (GameObject)Instantiate(TilePrefabs[2], currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
			

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void spawnTiles(){
		if(curSide == side.left){
			//build 2 to the left and 2 more up
			currentTile =  (GameObject)Instantiate(TilePrefabs[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
			//1 up
			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
			//1 right
			currentTile =  (GameObject)Instantiate(TilePrefabs[2], currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
			//1 up
			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
			//1 left
			currentTile =  (GameObject)Instantiate(TilePrefabs[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
			
			}
		if(curSide == side.top){
			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
			
		}
		if(curSide == side.right){
			currentTile =  (GameObject)Instantiate(TilePrefabs[2], currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
			//1 up
			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
			//1 left
			currentTile =  (GameObject)Instantiate(TilePrefabs[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
			//1 up
			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
			//1 right
			currentTile =  (GameObject)Instantiate(TilePrefabs[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
			
		}
	}
}
