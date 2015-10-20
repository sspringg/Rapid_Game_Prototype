using UnityEngine;
using System.Collections;
using System;
public class Monkey : MonoBehaviour {
	Vector3 oldVelocity, acceleration, testPosition, leftHand, diffVec = new Vector3(); 
	public Rigidbody rb;
	public bool initiate = false;
	public float tetherLength = 10;
	private double dist;
	public HingeJoint anchor;
	// Use this for initialization
	void Start () {
//		acceleration = new Vector3(0f,-.1f,0f);
//		leftHand = new Vector3(3,30,17);
//		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		/** On left Click **/
		if(Input.GetKey("up")){
			//move the anchor to the correct position
			anchor.transform.position = new Vector3 (3, 30, 17);
			//zero out any rotation
			anchor.transform.rotation = Quaternion.identity;
			
			//Create HingeJoints
			joint = gameObject.AddComponent<HingeJoint> ();
			joint.axis = Vector3.back; /// (0,0,-1)
			joint.anchor = Vector3.zero;
			joint.connectedBody = anchor.rigidbody;
			anchorJoint = anchor.AddComponent<HingeJoint> ();
			anchorJoint.axis = Vector3.back; /// (0,0,-1)
			anchorJoint.anchor = Vector3.zero;
		}
		
		//Now just add Force!
		
		/** On left Click release **/
		
		else if(Input.GetKey("down")){
			Destroy (joint);
			Destroy (anchorJoint);
		}
	}

}

	
//	//		print("trans before: " + transform.position);
//	testPosition = transform.position + (rb.velocity * Time.deltaTime * 10);
//	//test to see if distance between possible position and pivot point is greater than our max distance
//	//		print(Vector3.Distance(testPosition,leftHand) > tetherLength);
//	print("trans pos " + transform.position + "  dist: " + Vector3.Distance(testPosition,leftHand));
//	if (Vector3.Distance(testPosition,leftHand) > tetherLength)   //hand == pivot point t
//	{
//		if(initiate == false){
//			print("first vel: " + rb.velocity.magnitude);
//			initiate = true;
//		}
//		//pull monkey back to the edge of the his arm
//		//			print("test: " + testPosition + "   tran: " + transform.position);	
//		diffVec = (testPosition - leftHand);
//		//			print("diff vEC " + diffVec);
//		dist = Math.Sqrt((diffVec.x * diffVec.x) + (diffVec.y * diffVec.y) + (diffVec.z * diffVec.z));
//		testPosition = leftHand + (diffVec / (float)dist) * tetherLength;	//normalize the position
//		//			print("test: " + testPosition + "   tran: " + transform.position);
//		print("normalized: " + (diffVec / (float)dist) * tetherLength);
//		
//		float speed = rb.velocity.magnitude;
//		print("before Vel: " + rb.velocity);
//		rb.velocity = (testPosition - leftHand);
//		print("after Vel" + rb.velocity);
//		
//		//				rb.velocity = rb.velocity * speed;
//		transform.position = testPosition;
//		print("new trans: " + transform.position);
//	}
//	print("vel: " + rb.velocity.magnitude);
//}


//		if(initiate == false){
//			rb.velocity = new Vector3(0,0,10);
//			initiate = true;
//		}
//		rb.velocity = rb.velocity + acceleration * (Time.deltaTime * 1/2);
//		print(rb.velocity);
//		transform.position = transform.position + (oldVelocity + GetComponent<Rigidbody>().velocity) * (Time.deltaTime * 1/2) / 2.0f;
//		oldVelocity = rb.velocity;	
