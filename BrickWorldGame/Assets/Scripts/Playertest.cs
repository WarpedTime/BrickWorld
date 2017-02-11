using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertest : MonoBehaviour
{
    private Vector3 position;
    private Vector3 totalforce;
    private bool platformbool,jumpingbool;
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
        this.leftandrightmovement();
        this.jumping();
        this.transform.position += totalforce;
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Cube")
        {
            jumpingbool = false;
            platformbool = true;
            totalforce.y = 0;
            Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
        }
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

}
