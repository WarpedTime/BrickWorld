using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplePlayer : MonoBehaviour {

	public float moveSpeed = 8.0F;
	public float jumpSpeed = 10.0F;
	public float gravity = 20.0F;
	private float vSpeed = 0; 

	Rigidbody rb;

	[SerializeField] bool grounded;
	[SerializeField] bool wasGrounded;
	[SerializeField] bool overDoor = false;
	public GameObject door;

	void Start(){
		//controller = GetComponent<CharacterController>();
		rb=GetComponent<Rigidbody>();
	}


	void Update() {

		if (Input.GetKey(KeyCode.LeftArrow)) {
			//Debug.Log ("L");
			rb.AddForce (new Vector3(0,0,-moveSpeed));
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			//Debug.Log ("R");
			rb.AddForce (new Vector3(0,0,moveSpeed));
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			//Debug.Log ("U");

			if (overDoor) {
				Debug.Log ("Use Door");
				GameObject.Find ("GM").GetComponent<GameManagerScript> ().SendMessage ("enterDoor", door);
				return;
			}
			rb.AddForce (new Vector3(0,moveSpeed,0));
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			//Debug.Log ("D");
			rb.AddForce (new Vector3(0,-moveSpeed,0));
		}
		if (Input.GetKeyDown(KeyCode.G)) {
			//Debug.Log ("G");
			rb.AddForce (new Vector3(0,-gravity,0));
		}

	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Enter "+ other.name);
		if (other.tag == "door") {
			overDoor = true;
			door = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other){
		Debug.Log ("Exit "+other.name);
		if (other.tag == "door") {
			overDoor = false;
			door = null;
		}
	}

	public void Spawn(){
		door = null;
		overDoor = false;
		rb.velocity = Vector3.zero;
		transform.position = GameObject.Find("*").gameObject.transform.position;
	}

}
