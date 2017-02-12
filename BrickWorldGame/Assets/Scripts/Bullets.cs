using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform" || other.tag == "Mover")
        {
            Destroy(this.gameObject);
        }
    }

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
