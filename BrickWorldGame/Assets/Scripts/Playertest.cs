using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertest : MonoBehaviour
{
    private Vector3 position;
    private Vector3 totalforce;
    private bool platformbool,jumpingbool;

	[SerializeField] bool overDoor = false;
	public GameObject door;

    // Use this for initialization
    void Start()
    {
        totalforce = new Vector3(0.0f,0.0f,0.0f);
        platformbool = false;
        jumpingbool = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey (KeyCode.W)) {
			if (overDoor) {
				Debug.Log ("Use Door");
				GameObject.Find ("GM").GetComponent<GameManagerScript> ().SendMessage ("enterDoor", door);
				return;
			}
		}
        this.leftandrightmovement();
        this.jumping();
        this.transform.position += totalforce;
    }

    public void OnCollisionEnter(Collision collision)
    {

    }

	public void OnCollisionExit(Collision collision)
	{

	}

    public void leftandrightmovement()
    {
        //D forward direction
        if (Input.GetKey(KeyCode.D))
        {
            totalforce.z += .08f;
        }
        //A backward movement
        else if(Input.GetKey(KeyCode.A))
        {
            totalforce.z -= .08f;
        }
        //top speed
        if(totalforce.z > .7f)
        {
            totalforce.z = .1f;
        }
        if(totalforce.z<-.7f)
        {
            totalforce.z = -.1f;
        }
        //decceleration
        float decceleration = (totalforce.z - 0) / 3;
        totalforce.z -= decceleration;
    }

    public void jumping()
    {
        //w jump action
        if (Input.GetKey(KeyCode.W) && jumpingbool == false)
        {

            totalforce.y += 0.3f;
            platformbool = false;
            jumpingbool = true;
        }
        //gravity
        if (platformbool == false)
        {
            totalforce.y -= 0.01f;
        }

    }

	void OnTriggerEnter(Collider other){
		Debug.Log ("Enter "+ other.name);
		if (other.tag == "door") {
			overDoor = true;
			door = other.gameObject;
		}

		if(other.transform.tag == "Platform")
		{
            if (this.transform.position.y - 1.65 > other.transform.position.y)
            {
                jumpingbool = false;
                platformbool = true;
                totalforce.y = 0;
                Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
                rb.velocity = new Vector3(0, 0, rb.velocity.z);
            }
		}
        if(other.transform.tag == "Mover")
        {
            transform.parent = other.transform;
            jumpingbool = false;
            platformbool = true;
            totalforce.y = 0;
            Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, rb.velocity.z);
        }
	}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay " + other.name);
        if (other.tag == "door")
        {
            overDoor = true;
            door = other.gameObject;
        }

        if (other.transform.tag == "Platform")
        {
            if (this.transform.position.y - 1.65 > other.transform.position.y)
            {
                jumpingbool = false;
                platformbool = true;
                totalforce.y = 0;
                Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
                rb.velocity = new Vector3(0, 0, rb.velocity.z);
            }
        }
        if (other.transform.tag == "Mover")
        {
            transform.parent = other.transform;
            jumpingbool = false;
            platformbool = true;
            totalforce.y = 0;
            Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, rb.velocity.z);
        }
    }

    void OnTriggerExit(Collider other){
		Debug.Log ("Exit "+other.name);
		if (other.tag == "door") {
			overDoor = false;
			door = null;
		}

		if(other.transform.tag == "Platform")
		{
			jumpingbool = true;
			platformbool = false;
		}
        if (other.transform.tag == "Mover")
        {
            transform.parent = null;
        }
    }

	public void Spawn(){
		door = null;
		overDoor = false;
		Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
		rb.Sleep ();
		Vector3 pos = GameObject.Find("*").gameObject.transform.position;
		transform.position = pos;
	}

	public void kill(){
		Debug.Log ("player died!");
		Spawn ();
	}

}
