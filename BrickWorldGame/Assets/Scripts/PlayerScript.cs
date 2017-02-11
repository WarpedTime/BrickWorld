using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float moveSpeed = 8.0F;
	public float jumpSpeed = 10.0F;
	public float gravity = 20.0F;
	private float vSpeed = 0; 

	private Vector3 moveDirection = Vector3.zero;

	private Vector3 acceleration = Vector3.zero;
	private Vector3 velocity = Vector3.zero;
	private Vector3 desiredDir = Vector3.zero;

	Vector3 vertical = new Vector3(0,1,0);

	public float maxSpeed = 10f;
	public float maxForce = 15f;
	public float mass = 1f;
	public float radius = 1f;
	public float minDist = 2;

	CharacterController controller;
	Rigidbody rb;

	int jumpNum = 0;

	[SerializeField] bool grounded;
	[SerializeField] bool wasGrounded;

	void Start(){
		velocity = transform.forward;
		//controller = GetComponent<CharacterController>();
		rb=GetComponent<Rigidbody>();
	}


	void Update() {
//		grounded = controller.isGrounded;
//
//		if (controller.isGrounded) {
//
//		}
//		//reset vertical vel if landed
//		if (grounded && !wasGrounded) {
//			velocity = Vector3.zero;
//			Debug.Log ("landed");
//		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			Debug.Log ("L");
			rb.AddForce (new Vector3(0,0,-10));
			//controller.Move (new Vector3(0,0,-10)*Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			Debug.Log ("R");
			rb.AddForce (new Vector3(0,0,10));
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			Debug.Log ("U");
			rb.AddForce (new Vector3(0,500,0));
		}

		rb.AddForce (new Vector3(0,-12,0));

		//doThing ();
//		wasGrounded = grounded;
	}

	void doThing(){

		if (Input.GetButtonDown("Jump")) {
			Debug.Log ("jumping");

			//moveDirection.y += jumpSpeed;
			applyForce(new Vector3(0,1,0)* jumpSpeed);
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			Debug.Log ("L");
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			Debug.Log ("R");
		}

		moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"))* moveSpeed;
		moveDirection.x *= moveSpeed;

		applyForce(moveDirection);
		applyForce ((vertical * (-1)) * gravity);

		velocity += acceleration * Time.deltaTime;
		velocity.x = 0;

		controller.Move (velocity*Time.deltaTime);

		//reset
		acceleration = Vector3.zero;
		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);
	}

	//add a force onto the player
	void applyForce(Vector3 steeringForce){
		acceleration += steeringForce / mass;
	}

	Vector3 seek(Vector3 targetPos){
		desiredDir = targetPos - transform.position;
		desiredDir.Normalize();
		desiredDir*= maxSpeed;

		Vector3 steer = desiredDir - velocity;
		desiredDir.x=0;
		return steer;
	}

}
