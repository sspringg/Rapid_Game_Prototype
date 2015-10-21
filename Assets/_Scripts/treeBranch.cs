using UnityEngine;
using System.Collections;
using System;
public class treeBranch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		Monkey.S.pivot = new Vector3((float)Monkey.S.transform.position.x, (float)gameObject.transform.position.y, (float)gameObject.transform.position.z);
		if(Input.GetMouseButton(0)){
			Monkey.S.swinging = true;
			Monkey.S.realMagnitude = Monkey.S.rb.velocity.magnitude;
//			float dist = (float)Math.Sqrt((Monkey.S.rb.velocity.x * Monkey.S.rb.velocity.x) + (Monkey.S.rb.velocity.y * Monkey.S.rb.velocity.y) + (Monkey.S.rb.velocity.z * Monkey.S.rb.velocity.z));
			Monkey.S.rb.velocity = Monkey.S.rb.velocity;// / dist;
		}
	}
}
