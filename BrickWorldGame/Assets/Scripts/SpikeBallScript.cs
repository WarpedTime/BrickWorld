using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallScript : MonoBehaviour {

	[SerializeField] bool hidden;

	// Use this for initialization
	void Start () {
		GetComponent<Animator> ().SetBool ("hidden", hidden);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Enter "+ other.name);

		if(other.transform.tag == "Player")
		{
			if(GetComponent<Animator> ().GetBool("hidden"))
			GetComponent<Animator> ().Play ("spikeBall_hidden");
			else
			GetComponent<Animator> ().Play ("spikeBall");
		}
	}
}
