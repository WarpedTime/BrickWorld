using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonPressed()
    {
        Debug.Log("The Gate is Open");
        Destroy(this.gameObject);
    }
}
