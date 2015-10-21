using UnityEngine;
using System.Collections;

public class treeTrunk : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		print("trunk");
		Main.S.placeInDialog = 11;
		Main.S.Play_Dialog();
	}
}
