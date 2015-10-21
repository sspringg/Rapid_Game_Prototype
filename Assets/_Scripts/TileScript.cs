using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {
	public GameObject left, top, right;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
		}
	}
}
