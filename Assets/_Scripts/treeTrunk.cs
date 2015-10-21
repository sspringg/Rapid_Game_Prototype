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
//		if(Monkey.S.transform.position.z > 300 && Monkey.S.transform.position.z < 310)
//			return;
		if(other.tag == "Player"){
			print(Monkey.S.transform.position);
			Main.S.placeInDialog = 11;
			Main.S.Play_Dialog();
		}
	}
}
