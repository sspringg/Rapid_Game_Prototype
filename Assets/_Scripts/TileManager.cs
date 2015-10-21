/*base map Generation algorithm taken from http://educationsbestnews.blogspot.com/
Information on how to use provided by https://www.youtube.com/watch?v=cUAprBYS_0Q
under the Standard YouTube License
*/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class TileManager : MonoBehaviour
{
	public static TileManager S;
	public GameObject Monkey;
	public GameObject TreeTrunk;
	public GameObject TreeBranch;
	public GameObject Banana;
	public static Queue<GameObject> treeQ = new Queue<GameObject>();
	private int lastZgenerated, lastYRow = 1;
	private Terrain[,] map = new Terrain[3,3], newTerrain;
	private bool openning = true; 
	private Vector3[] branchPos;
	void Start ()
	{
		S = this;
		Terrain curTerrain = gameObject.GetComponent<Terrain>();
		
		//set all initial map places
		map[0,0] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		map[0,1] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		map[0,2] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		map[1,0] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		//keep player in middle of map
		map[1,1] = curTerrain; 
		//map ahead of player
		map[1,2] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		map[2,0] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		map[2,1] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();
		map[2,2] = Terrain.CreateTerrainGameObject(curTerrain.terrainData).GetComponent<Terrain>();

		branchPos = new Vector3[6];
		branchPos[0] = new Vector3(4,35,0);
		branchPos[1] = new Vector3(4,25,0);
		branchPos[2] = new Vector3(4,10,0);
		branchPos[3] = new Vector3(-20,35,0);
		branchPos[4] = new Vector3(-25,25,0);
		branchPos[5] = new Vector3(-25,10,0);

		UpdateTerrain();
		//initial tree for us to land on with player at(224,100,100) initial motion 20 forwar and 10 up
		GameObject obj = Instantiate(TreeTrunk, new Vector3(210, 0, 203), Quaternion.identity) as GameObject;
		obj.transform.Rotate(-90, 0, 0);
		GameObject branch = Instantiate(TreeBranch, new Vector3((float)(obj.transform.position.x + 4), (float)(obj.transform.position.y + 30), (float)(obj.transform.position.z)), Quaternion.identity) as GameObject;
		branch.transform.Rotate(0, 90, 0);
		branch.transform.localScale += new Vector3(.4f, .4f, 3f); 
		branch.transform.parent = obj.transform;
		
		int initGenerateZ = 100;
		lastZgenerated = (int)map[0,0].transform.position.z;
		for(int x = 0; x <= 2; ++x){
			generateTrees(x, lastYRow, initGenerateZ);
		}
	}
	
	void UpdateTerrain(){
		//terrainData.size = total size in world unit of terrain
		map[0,0].transform.position = new Vector3(map[1,1].transform.position.x - map[1,1].terrainData.size.x, map[1,1].transform.position.y, map[1,1].transform.position.z + map[1,1].terrainData.size.z);
		map[0,1].transform.position = new Vector3(map[1,1].transform.position.x - map[1,1].terrainData.size.x, map[1,1].transform.position.y,map[1,1].transform.position.z);
		map[0,2].transform.position = new Vector3(map[1,1].transform.position.x - map[1,1].terrainData.size.x,map[1,1].transform.position.y, map[1,1].transform.position.z - map[1,1].terrainData.size.z);
		map[1,0].transform.position = new Vector3(map[1,1].transform.position.x, map[1,1].transform.position.y, map[1,1].transform.position.z + map[1,1].terrainData.size.z);
		map[1,2].transform.position = new Vector3(map[1,1].transform.position.x, map[1,1].transform.position.y, map[1,1].transform.position.z - map[1,1].terrainData.size.z);
		map[2,0].transform.position = new Vector3(map[1,1].transform.position.x + map[1,1].terrainData.size.x,map[1,1].transform.position.y, map[1,1].transform.position.z + map[1,1].terrainData.size.z);
		map[2,1].transform.position = new Vector3(map[1,1].transform.position.x + map[1,1].terrainData.size.x, map[1,1].transform.position.y, map[1,1].transform.position.z);
		map[2,2].transform.position = new Vector3(map[1,1].transform.position.x + map[1,1].terrainData.size.x, map[1,1].transform.position.y, map[1,1].transform.position.z - map[1,1].terrainData.size.z);
	}
	
	void Update(){
		Vector3 playerPosition = Monkey.transform.position;
		Terrain curTerrain = null;
		int curX = 0;
		int curY = 0;
		//loop through each element of arrray
		for (int x = 0; x < 3; x++){
			for (int y = 0; y < 3; y++){
				//find the current part of the map our player is in
				//position is from pivot point(here bottom-left corner)
				if ((playerPosition.x >= map[x,y].transform.position.x) &&
					(playerPosition.x <= (map[x,y].transform.position.x + map[x,y].terrainData.size.x))){
					if((playerPosition.z >= map[x,y].transform.position.z) &&
					   (playerPosition.z <= (map[x,y].transform.position.z + map[x,y].terrainData.size.z))){
						curTerrain = map[x,y];	//set which tile the player is in!!
						curX = 1 - x; //
						curY = 1 - y;
						break;
					}
				}
			}
			if (curTerrain != null)	//found our current Terrain so break
				break;
		}
		//always want player in the middle so fix if she isnt
			if(curTerrain != map[1,1]){
				print("moving tiles");
				newTerrain = new Terrain[3,3];
				for (int x = 0; x < 3; x++)
					for (int y = 0; y < 3; y++){			//(2,0) (1,0), (0,0) [
						int newX = x + curX;
						if (newX < 0)
							newX = 2;
						else if (newX > 2)
							newX = 0;
						int newY = y + curY;
						if (newY < 0)
							newY = 2;
						else if (newY > 2)
							newY = 0;
						newTerrain[newX, newY] = map[x,y];
					}
			for (int x = 0; x < 3; x++){
				for (int y = 0; y < 3; y++){
					map[x, y] = newTerrain[x, y];
				}
			}
				map = newTerrain;
				UpdateTerrain();
		}
		if((lastZgenerated - Monkey.transform.position.z) < 200){
			for (int k = 0; k < 3; k++)
				generateTrees(k, lastYRow, 1);	
			lastZgenerated += UnityEngine.Random.Range(45, 59);
		}
	}
	void generateTrees(int x, int y, int zGenDist){
		float randVal;
		float tileX = map[x,y].transform.position.x;
		float tileZ = map[x,y].transform.position.z;
		float tileSizeX = map[x,y].terrainData.size.x;
		float tileSizeZ = map[x,y].terrainData.size.z;
		float i = tileZ, j = tileX;
		while(i < (lastZgenerated + zGenDist)){
			while(j < (tileX + tileSizeX)){
				randVal = UnityEngine.Random.value;
				if(randVal < .5){
					Vector3 pos = new Vector3(j,0,i);
					GameObject obj = Instantiate(TreeTrunk, pos, Quaternion.identity) as GameObject;
					treeQ.Enqueue(obj);
					if(treeQ.Count > 250){
						GameObject objToDestroy = treeQ.Peek();
						Destroy(objToDestroy);
						treeQ.Dequeue();
					}
					obj.transform.Rotate(-90, 0, 0);
					obj.transform.parent = map[x,y].transform;
					int branchRand = (int)UnityEngine.Random.Range(0,6);
					switch(branchRand){
						case 1:
							branchCreator(obj, branchPos[0]); //upper right
						break;
						case 2:
							branchCreator(obj, branchPos[3]); //upper left
						break;
						case 3:
							branchCreator(obj, branchPos[0]); //top bottom right
							branchCreator(obj, branchPos[2]);
						break;
						case 4:
							branchCreator(obj, branchPos[0]); //top right middle left
							branchCreator(obj, branchPos[4]);
						break;
						case 5:
							branchCreator(obj, branchPos[3]);  //upper left, bottom left mid right
							branchCreator(obj, branchPos[5]);
							branchCreator(obj, branchPos[1]);
						break;
						case 6:
							branchCreator(obj, branchPos[4]);  //bottom left middle left
							branchCreator(obj, branchPos[5]);
						break;
					
					}					
				}
				j += UnityEngine.Random.Range(45, 59);
				if(Math.Abs(j - 224) < 20 && Math.Abs(i - 194) < 20){
					i += UnityEngine.Random.Range(45, 59);
					j += UnityEngine.Random.Range(45, 59);
				}
			}
			j = tileX;
			i += UnityEngine.Random.Range(45, 59);
		}
//		List<GameObject> children = new List<GameObject>();
//		foreach (Transform child in transform){
//			children.Add(child.gameObject);
//		}
//		foreach(GameObject childIn in children){
//			print("destroy");
//			if((lastZgenerated - childIn.transform.position.z) > 205)
//				Destroy(childIn);
//		}
				
	}
	void branchCreator(GameObject obj, Vector3 inVec){
		Vector3 branchVec =  new Vector3((float)(obj.transform.position.x + inVec.x), (float)(obj.transform.position.y + inVec.y), (float)(obj.transform.position.z));
		GameObject branch = Instantiate(TreeBranch, branchVec, Quaternion.identity) as GameObject;
		branch.transform.Rotate(0, 90, 0);
		branch.transform.localScale += new Vector3(.4f, .4f, 3f); 
		branch.transform.parent = obj.transform;
		if(UnityEngine.Random.Range(0,100) < 20){
			Vector3 bananaVec =  new Vector3((float)(obj.transform.position.x + inVec.x + 10), (float)(obj.transform.position.y + inVec.y - 5), (float)(obj.transform.position.z));
			GameObject banana = Instantiate(Banana, bananaVec, Quaternion.identity) as GameObject;
			banana.transform.Rotate(270, 180, 180);
			banana.transform.parent = branch.transform;
		}
		
	}
}
