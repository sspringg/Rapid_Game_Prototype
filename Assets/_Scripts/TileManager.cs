//using UnityEngine;
//using System.Collections;
//public enum side{
//	left,
//	top,
//	right
//}
//public class TileManager : MonoBehaviour {
//	public static TileManager S;
//	public GameObject currentTile, leftTile, topTile, rightTile;
//	public GameObject TreeTrunk;
//	public GameObject[] TilePrefabs, assignmentPrefabs;
//	public side curSide = side.top;
//	
//	// Use this for initialization
//	void Start () {
//		S = this;
//		Terrain linkedTerrain = gameObject.GetComponent<Terrain>();
//		
//		_terrainGrid[0,0] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
//		_terrainGrid[0,1] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
//		_terrainGrid[0,2] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
//		_terrainGrid[1,0] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
//		_terrainGrid[1,1] = linkedTerrain;
//		_terrainGrid[1,2] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
//		_terrainGrid[2,0] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
//		_terrainGrid[2,1] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
//		_terrainGrid[2,2] = Terrain.CreateTerrainGameObject(linkedTerrain.terrainData).GetComponent<Terrain>();
//		
//		UpdateTerrainPositionsAndNeighbors();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//	public void spawnTiles(){
//		if(curSide == side.left){
//			//build 2 to the left and 2 more up
//			currentTile =  (GameObject)Instantiate(TilePrefabs[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			//1 up
//			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			//1 right
//			currentTile =  (GameObject)Instantiate(TilePrefabs[2], currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			//1 up
//			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			//1 left
//			currentTile =  (GameObject)Instantiate(TilePrefabs[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			
//			}
//		if(curSide == side.top){
//			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
//			
//		}
//		if(curSide == side.right){
//			currentTile =  (GameObject)Instantiate(TilePrefabs[2], currentTile.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			//1 up
//			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			//1 left
//			currentTile =  (GameObject)Instantiate(TilePrefabs[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			//1 up
//			currentTile =  (GameObject)Instantiate(TilePrefabs[1], currentTile.transform.GetChild(0).transform.GetChild(2).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			//1 right
//			currentTile =  (GameObject)Instantiate(TilePrefabs[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
//		Instantiate(TreeTrunk, new Vector3(currentTile.transform.position.x , 0, currentTile.transform.position.z ),Quaternion.identity);
//			
//		}
//	}
//}
