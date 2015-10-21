using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	public static Fire S;
	// Use this for initialization
	
	void Awake(){
		S = this;
	}
	
	void Start () {
		transform.position = new Vector3(Monkey.S.transform.position.x, 0, Monkey.S.transform.position.z - 24);
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Monkey.S.transform.position.x, 0, transform.position.z);
		transform.position += (Vector3.forward * Time.deltaTime * 10);
		if(transform.position.z >= Monkey.S.transform.position.z){
			Main.S.placeInDialog = 13;
			Main.S.Play_Dialog();
		}
	}
}
