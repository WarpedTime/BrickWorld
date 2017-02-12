using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour {
    public GameObject projectile;

    public float fireRate = 1.5F;
    public int maxProjectiles = 5;
    public float speed = 10.0F;
    private float nextFire = 0.0F;
    
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            // fire bullet
            GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;

            //Physics.IgnoreCollision(clone.GetComponent<Collider>(), GetComponent<Collider>());

            /* foreach (Transform child in transform)
            {
                Physics.IgnoreCollision(clone.GetComponent<Collider>(), child.gameObject.GetComponent<Collider>());
            }*/
            //Physics.IgnoreCollision(clone.GetComponent<Collider>(), GetComponentInChildren<Collider>());


            clone.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            Destroy(clone, maxProjectiles * fireRate);
        }
	}
}
