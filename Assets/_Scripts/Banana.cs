using UnityEngine;
using System.Collections;

public class Banana : MonoBehaviour {
	private ParticleSystem part;
	// Use this for initialization
	void Start () {	}

	void OnTriggerEnter(){
		Destroy(gameObject, 0.1f);
	}
}
