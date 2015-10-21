using UnityEngine;
using System.Collections;

public class treeBranch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		Monkey.S.pivot = new Vector3((float)Monkey.S.transform.position.x, (float)gameObject.transform.position.y, (float)gameObject.transform.position.z);
		Monkey.S.swinging = true;
	}
}
