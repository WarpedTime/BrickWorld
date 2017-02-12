using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botton : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("touched");
        if (other.tag == "Player")
        {
            TheWall wall;
            wall = GameObject.Find("Cube").GetComponent<TheWall>();
            wall.ButtonPressed();
        }
    }
}
