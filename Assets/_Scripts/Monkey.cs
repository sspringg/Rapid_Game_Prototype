using UnityEngine;
using System.Collections;
using System;
public class Monkey : MonoBehaviour {
	public static Monkey S;
	private Vector3 testPosition, mousePos, worldPos, diffVec = new Vector3(); 
	public Vector3 pivot;
	public Rigidbody rb;
	public float tetherLength = 3;
	private double dist, mouseXPos; 
	private float rotationSpeed = 5;
	public bool swinging = false;
	private Camera cameraloc;
	RaycastHit hitInfo;
	// Use this for initialization
	void Start () {
		S = this;
		rb = GetComponent<Rigidbody>();
		rb.AddForce(Vector3.forward * 10);
//		rb.AddForce(Vector3.up * 10);
		mouseXPos = 0;
	}
	
	// Update is called once per frame
	void Update () {
//		if(swinging){
////			Time.timeScale = .1f;
//			rotationSpeed = 5;	
//			rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
//			testPosition = transform.position + rb.velocity * (Time.deltaTime);
//			if (Vector3.Distance(testPosition,pivot) > tetherLength){   //hand == pivot point t
//				//pull monkey back to the edge of the his arm
//				diffVec = (testPosition - pivot);
//				dist = Math.Sqrt((diffVec.x * diffVec.x) + (diffVec.y * diffVec.y) + (diffVec.z * diffVec.z));
//				testPosition = pivot + (diffVec / (float)dist) * tetherLength;	//normalize the position
//				
//				float speed = rb.velocity.magnitude;
//				rb.velocity = (testPosition - transform.position) / (Time.deltaTime);
//				if(speed > rb.velocity.magnitude)
//					rb.velocity *= (speed / rb.velocity.magnitude);
//				transform.position = testPosition;
//			}
//		}
//		if(Physics.Raycast(gameObject.transform.position, Vector3.left, out hitInfo, 1f, GetLayerMask(new string[] {"Floor"}))){
//			print("right");
//			TileManager.S.currentTile = hitInfo.collider.gameObject;
//			TileManager.S.curSide = side.right;
//		}
//		else if(Physics.Raycast(gameObject.transform.position, Vector3.forward, out hitInfo, 1f, GetLayerMask(new string[] {"Floor"}))){
//			print("top");
//			TileManager.S.currentTile = hitInfo.collider.gameObject;
//			TileManager.S.curSide = side.top;
//		}
//		else if(Physics.Raycast(gameObject.transform.position, Vector3.right, out hitInfo, 1f, GetLayerMask(new string[] {"Floor"}))){
//			print("left");
//			TileManager.S.currentTile = hitInfo.collider.gameObject;
//			TileManager.S.curSide = side.left;
//		}
//		if (Input.GetMouseButton(0) && swinging == true){		//timescale to 1
//			print(rb.velocity);
//			Time.timeScale = 1f;
//			swinging = false;
//			mousePos = Input.mousePosition;
//			mouseXPos = mousePos.x / Screen.width;
//			mouseXPos = (mouseXPos - .5);
//			print(rb.velocity);
//		}
//		else{	//in air
//			if(Input.GetKey(KeyCode.A) && rotationSpeed < 10)
//				rotationSpeed += .5f;
//			else if(Input.GetKey(KeyCode.S) && rotationSpeed > .5f){
//				rotationSpeed -= .5f;
//			}
//			transform.Rotate(Vector3.up * rotationSpeed);
//			transform.position = new Vector3(transform.position.x + (float)mouseXPos, (float)transform.position.y, (float)transform.position.z);
//		}
		if(Input.GetKey("left"))		//for testing purposes
			transform.position += Vector3.left;
		else if(Input.GetKey("right"))
			transform.position += Vector3.right;
		transform.position += Vector3.forward;
	}
	public int GetLayerMask(string[] layerNames){
		int layerMask = 0;
		foreach(string layer in layerNames){
			layerMask = layerMask | (1 << LayerMask.NameToLayer(layer)); //looks up name in layermask table
		}
		return layerMask;
	}

}

