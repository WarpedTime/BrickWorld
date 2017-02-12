using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour {
    public GameObject projectile;   // Needs to be Fireball class

    public float fireInterval = 1.5F;   // seconds
    public int destroyInterval = 10;   // seconds before object gets destroyed
    public float speed = 100.0F;   // in force units
    public float offset = 0.0F;   // offset from load 

	// Update is called once per frame
	void Update () {
        if (Time.time > offset)
        {
            offset = Time.time + fireInterval;

            GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * speed);

            // destroy prjectile
            Destroy(clone, destroyInterval);
        }
	}
}
