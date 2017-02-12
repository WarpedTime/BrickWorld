using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {

	[SerializeField] public GameObject SpawnPoint;
	public bool roomReady = false;

	// Use this for initialization
	void Start () {
		roomReady = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
