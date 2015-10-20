using UnityEngine;
using System.Collections;

public class Camera_Script : MonoBehaviour {

	public Transform target;
	public float distance;
	void Update(){
		
		transform.position = new Vector3(target.position.x, target.position.y + distance - 5, target.position.z - distance);
	}
}
