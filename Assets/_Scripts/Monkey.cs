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
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey("up")){
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
}

//		if(initiate == false){
//			rb.velocity = new Vector3(0,0,10);
//			initiate = true;
//		}
//		rb.velocity = rb.velocity + acceleration * (Time.deltaTime * 1/2);
//		print(rb.velocity);
//		transform.position = transform.position + (oldVelocity + GetComponent<Rigidbody>().velocity) * (Time.deltaTime * 1/2) / 2.0f;
//		oldVelocity = rb.velocity;	
