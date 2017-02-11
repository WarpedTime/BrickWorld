using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTouch : MonoBehaviour {


    void OnCollisionEnter(Collision collision)
    {
        // assuming "PlayerScript"
        // check if collison is with player
        if (collision.collider.tag == "PlayerScript")
        {
            // kill player
            PlayerScript p;

            p = collision.collider.GetComponent<PlayerScript>();

            p.kill();
        }
    }
}
