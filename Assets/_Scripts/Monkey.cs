using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class Monkey : MonoBehaviour {
	public static Monkey S;
	private Vector3 testPosition, mousePos, worldPos, diffVec = new Vector3(); 
	public Vector3 pivot, beforePause;
	public Rigidbody rb;
	public float tetherLength = 3;
	private double dist, mouseXPos; 
	private float rotationSpeed = 5;
	public bool swinging = false;
	private Camera cameraloc;
	public float realMagnitude;
	public float distTravelled = 0;
	RaycastHit hitInfo;
	// Use this for initialization
	void Start () {
		S = this;
		rb = GetComponent<Rigidbody>();
		rb.AddForce(Vector3.forward * 20);
		rb.AddForce(Vector3.up * 10);
		mouseXPos = 0;
	}

	// Update is called once per frame
	void Update () {
		if(!Main.S.inDialog){
//			if(Input.GetKey("left"))		//for testing purposes
//				transform.position += (Vector3.left*5);
//			else if(Input.GetKey("right"))
//				transform.position += (Vector3.right * 5);
//			transform.position += Vector3.forward;
			
			if(swinging){
				rotationSpeed = 5;	
				rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
				testPosition = transform.position + rb.velocity * (Time.deltaTime);
				if (Vector3.Distance(testPosition,pivot) > tetherLength){   //hand == pivot point t
					//pull monkey back to the edge of the his arm
					diffVec = (testPosition - pivot);
					dist = Math.Sqrt((diffVec.x * diffVec.x) + (diffVec.y * diffVec.y) + (diffVec.z * diffVec.z));
					testPosition = pivot + (diffVec / (float)dist) * tetherLength;	//normalize the position
					
					float speed = rb.velocity.magnitude;
					rb.velocity = (testPosition - transform.position) / (Time.deltaTime);
					rb.velocity /= 8;
					if(speed > rb.velocity.magnitude)
						rb.velocity *= (speed / rb.velocity.magnitude);
					transform.position = testPosition;
				}
			}
			//monkey Hit ground
			if(transform.position.y < 4){
				Main.S.placeInDialog = 8;
				Main.S.Play_Dialog();
			}
			if (Input.GetMouseButtonUp(0) && swinging == true){		//user releases grab
				swinging = false;
				mousePos = Input.mousePosition;
				mouseXPos = mousePos.x / Screen.width;
				mouseXPos = (mouseXPos - .5) * 1.25;
				rb.velocity *= 2;
			}
			else if(!swinging){	//in air
				if(Input.GetKey(KeyCode.A) && rotationSpeed < 10)
					rotationSpeed += .5f;
				else if(Input.GetKey(KeyCode.S) && rotationSpeed > .5f)
					rotationSpeed -= .5f;
				distTravelled += (rb.velocity.z * Time.deltaTime);
				GameObject dialogBox = GameObject.Find("Score").transform.Find("Text").gameObject;
				Text goText = dialogBox.GetComponent<Text>();
				goText.text = ((int)Monkey.S.distTravelled).ToString();
				transform.Rotate(Vector3.up * rotationSpeed);
				transform.position = new Vector3(transform.position.x + (float)mouseXPos, (float)transform.position.y, (float)transform.position.z);
			}
		}
	}

	public int GetLayerMask(string[] layerNames){
		int layerMask = 0;
		foreach(string layer in layerNames){
			layerMask = layerMask | (1 << LayerMask.NameToLayer(layer)); //looks up name in layermask table
		}
		return layerMask;
	}

}

