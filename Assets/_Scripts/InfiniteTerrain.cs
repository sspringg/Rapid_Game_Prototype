using UnityEngine;
using System.Collections;

public class InfiniteTerrain : MonoBehaviour
{
	public static InfiniteTerrain S;
	public GameObject Monkey;
	public GameObject TreeTrunk;
	private Terrain[,] map = new Terrain[3,2];
	
	void Start ()
	{
		S = this;
		Terrain curTerrain = gameObject.GetComponent<Terrain>();
		
		//set all initial map places
		map[0,0] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		map[0,1] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		map[1,0] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		//keep player in middle of map
		map[1,1] = curTerrain;
		//map ahead of player
		map[2,0] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		map[2,1] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		print( map[1,1].terrainData.size.x + " " +  map[1,1].terrainData.size.z);

		UpdateTerrain();
		for(int x = 0; x <= 2; ++x){
			for(int y = 0; y <= 1; ++y){
				generateTrees(x, y);
			}
		}
	}
	
	void UpdateTerrain(){
		//terrainData.size = total size in world unit of terrain
		map[0,0].transform.position = new Vector3(
			map[1,1].transform.position.x - map[1,1].terrainData.size.x,
			map[1,1].transform.position.y,
			map[1,1].transform.position.z + map[1,1].terrainData.size.z);
		map[0,1].transform.position = new Vector3(
			map[1,1].transform.position.x - map[1,1].terrainData.size.x,
			map[1,1].transform.position.y,
			map[1,1].transform.position.z);
		
		map[1,0].transform.position = new Vector3(
			map[1,1].transform.position.x,
			map[1,1].transform.position.y,
			map[1,1].transform.position.z + map[1,1].terrainData.size.z);
		
		map[2,0].transform.position = new Vector3(
			map[1,1].transform.position.x + map[1,1].terrainData.size.x,
			map[1,1].transform.position.y,
			map[1,1].transform.position.z + map[1,1].terrainData.size.z);
		map[2,1].transform.position = new Vector3(
			map[1,1].transform.position.x + map[1,1].terrainData.size.x,
			map[1,1].transform.position.y,
			map[1,1].transform.position.z);
	}
	
	void Update(){
		Vector3 playerPosition = Monkey.transform.position;
		Terrain curTerrain = null;
		int xDiff = 0, yDiff = 0;
		//loop through each element of arrray
		for (int x = 0; x < 3; x++){
			for (int y = 0; y < 2; y++){
				//find the current part of the map our player is in
				//position is from pivot point(here bottom-left corner)
				if ((playerPosition.x >= map[x,y].transform.position.x) &&
					(playerPosition.x <= (map[x,y].transform.position.x + map[x,y].terrainData.size.x))){
					if((playerPosition.z >= map[x,y].transform.position.z) &&
					   (playerPosition.z <= (map[x,y].transform.position.z + map[x,y].terrainData.size.z))){
						curTerrain = map[x,y];	//set which 
						xDiff = 1 - x; //
						yDiff = 1 - y;
						break;
					}
				}
			}
			if (curTerrain != null)	//found our current Terrain so break
				break;
		}
		//always want player in the middle so fix if she isnt
			if(curTerrain != map[1,1]){
				Terrain[,] newTerrain = new Terrain[3,2];
				for (int x = 0; x < 3; x++){
					for (int y = 0; y < 2; y++){
						int newX = x + xDiff;
						if (newX < 0)
							newX = 2;
						else if (newX > 2)
							newX = 0;
						int newY = y + yDiff;
						if (newY < 0)
							newY = 1;
						else 
							newY = 0;
//						newTerrain[newX, newY] = map[x,y];
					}
//				map = newTerrain;
				UpdateTerrain();
			}
		}
	}
	void generateTrees(int x, int y){
		float randVal;
		float tileX = map[x,y].transform.position.x;
		float tileZ = map[x,y].transform.position.z;
		float tileSizeX = map[x,y].terrainData.size.x;
		float tileSizeZ = map[x,y].terrainData.size.z;
		print(tileX + "  " + tileZ);
		float i = tileZ, j = tileX;
		while(i < (tileZ + tileSizeZ)){
			print("iout : " + i);
		
			while(j < (tileX + tileSizeX)){
//				print("j: " + j);
				randVal = Random.value;
				if(randVal < .5){
					print("i: " + i);
					Vector3 pos = new Vector3(j,0,i);
					Quaternion p = Quaternion.identity;
					p[0] = 270f;
					GameObject obj = Instantiate(TreeTrunk, pos, p) as GameObject;
//					print("Randval: " + randVal);
					print(pos);
					obj.transform.parent = map[x,y].transform;
				}
				j += Random.Range(5, 8);
			}
			j = tileX;
			i += Random.Range(5, 8);
		}
		foreach (Transform child in map[x,y].transform)
		{
			if(child.transform.position.z < tileZ)
				Destroy(child, .25f);
		}
		
	}
}
