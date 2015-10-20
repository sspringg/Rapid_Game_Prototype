using UnityEngine;
using System.Collections;
using System;
public class Monkey : MonoBehaviour {
	Vector3 testPosition, pivot, diffVec = new Vector3(); 
	public Rigidbody rb;
	public float tetherLength = 10;
	private double dist; 
	public HingeJoint anchor;
	private float rotationSpeed = 5;
	private bool pivotSet = false;
	RaycastHit hitInfo;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddForce(Vector3.forward * 10);
		rb.AddForce(Vector3.up * 10);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Physics.Raycast(gameObject.transform.position, Vector3.left, out hitInfo, 1f, GetLayerMask(new string[] {"Floor"}))){
			print("right");
			TileManager.S.currentTile = hitInfo.collider.gameObject;
			TileManager.S.curSide = side.right;
		}
		else if(Physics.Raycast(gameObject.transform.position, Vector3.forward, out hitInfo, 1f, GetLayerMask(new string[] {"Floor"}))){
			print("top");
			TileManager.S.currentTile = hitInfo.collider.gameObject;
			TileManager.S.curSide = side.top;
		}
		else if(Physics.Raycast(gameObject.transform.position, Vector3.right, out hitInfo, 1f, GetLayerMask(new string[] {"Floor"}))){
			print("left");
			TileManager.S.currentTile = hitInfo.collider.gameObject;
			TileManager.S.curSide = side.left;
		}
//		if(Input.GetKey("left"))
//			transform.position += Vector3.left;
//		else if(Input.GetKey("right"))
//			transform.position += Vector3.right;
//		transform.position += Vector3.forward;
		else if(Physics.Raycast(gameObject.transform.position, out hitInfo, 1f, GetLayerMask(new string[] {"treeBranch"})) 
		        && Input.GetMouseButtonDown(0)){
		        print("wooo");
			rotationSpeed = 5;	
			if(pivotSet == false){
				pivot = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
				pivotSet = true;
			}
			rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
				testPosition = transform.position + rb.velocity;
				if (Vector3.Distance(testPosition,pivot) > tetherLength){   //hand == pivot point t
					//pull monkey back to the edge of the his arm
					diffVec = (testPosition - pivot);
					dist = Math.Sqrt((diffVec.x * diffVec.x) + (diffVec.y * diffVec.y) + (diffVec.z * diffVec.z));
					testPosition = pivot + (diffVec / (float)dist) * tetherLength;	//normalize the position
					
					float speed = rb.velocity.magnitude;
					rb.velocity = (testPosition - transform.position);
					if(speed > rb.velocity.magnitude)
						rb.velocity *= (speed / rb.velocity.magnitude);
					transform.position = testPosition;
				}
			}
		else if (Input.GetKeyUp("up")){
			pivotSet = false;
		}
		else{
			if(Input.GetKey(KeyCode.A) && rotationSpeed < 10)
				rotationSpeed += .5f;
			else if(Input.GetKey(KeyCode.S) && rotationSpeed > .5f){
				rotationSpeed -= .5f;
			}
			transform.Rotate(Vector3.up * rotationSpeed);
		}
	}

	public int GetLayerMask(string[] layerNames){
		int layerMask = 0;
		foreach(string layer in layerNames){
			layerMask = layerMask | (1 << LayerMask.NameToLayer(layer)); //looks up name in layermask table
		}
		return layerMask;
	}
	public Ray GetRay(){
		switch(direction){
		case Direction.down:
			return new Ray (pos, Vector3.down);
		case Direction.up:
			return new Ray (pos, Vector3.up);
		case Direction.left:
			return new Ray (pos, Vector3.left);
		case Direction.right:
			return new Ray (pos, Vector3.right);
		default:
			return new Ray();	
		}
	}

}

