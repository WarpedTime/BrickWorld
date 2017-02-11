using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTouch : MonoBehaviour {


    void OnCollisionEnter(Collision collision)
    {
        // assuming "Player"

        // check if collison is with player
        if (collision.collider.tag == "Player") {
            // kill player
            Player p;

            p = collision.collider.GetComponent<Player>();

            p.kill();
        }

        return;
    }
}
