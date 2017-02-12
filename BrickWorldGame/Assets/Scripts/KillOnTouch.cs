using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTouch : MonoBehaviour {


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        // assuming "PlayerScript"
        // check if collison is with player
        if (collision.collider.tag == "Player")
        {
            // kill player
            Playertest p;

			p = collision.collider.GetComponent<Playertest>();

            p.kill();
        }
    }
}
