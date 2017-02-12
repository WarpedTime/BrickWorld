using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    private int score;

    [SerializeField] GameObject PlayerPrefab;
	[SerializeField] GameObject StartRoom;
    [SerializeField] float distancefromCamera;
    private Transform StartP;

	public GameObject currentRoom;
	public GameObject player;
	public int roomNum=0;

	[SerializeField] bool isDebug;
	[SerializeField] GameObject d_CurerntRoom;
	[SerializeField] GameObject d_Player;

	bool spawnedPlayer = false;

	// Use this for initialization
	void Start (){
		DontDestroyOnLoad (this.gameObject);

		if (isDebug) {
    
			score = 0;
        	
			currentRoom = d_CurerntRoom;
			player = d_Player;

			StartP = GameObject.Find ("Start_Point").transform;
			return;
		}


		score = 0;

		currentRoom = Instantiate (StartRoom, new Vector3 (distancefromCamera, 0, 0), Quaternion.identity);
		StartP = GameObject.Find ("Start_Point").transform;
		player = Instantiate (PlayerPrefab, StartP.position, Quaternion.identity);

	}

	void enterDoor(GameObject door){
		if (isDebug) {
			//get rid of debug start stuff
			GameObject.Destroy (currentRoom);
			//d_Player.SetActive (false);
		} else {
			//destroy previous room
			GameObject.Destroy (currentRoom);
			//GameObject.Destroy (player);
		}

		//increase visited room count
		roomNum++;

		//get next room
		GameObject newRoom = door.GetComponent<DoorScript> ().NextRoom;
		Debug.Log ("Entering "+ newRoom.name);

		//create new room
		currentRoom = Instantiate (newRoom, new Vector3 (distancefromCamera, 0, 0), Quaternion.identity);
		currentRoom.name += " [" + roomNum + "]";

		//setup and spawn player
		player.name = "player " + roomNum;
		//player.GetComponent<simplePlayer>().Spawn();
		spawnedPlayer=false;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)) {
			//Debug.Log ("D");
			SpawnPlayer();
		}

		if (!spawnedPlayer)
			SpawnPlayer ();

	}

	public void SpawnPlayer(){
		player.GetComponent<simplePlayer>().Spawn();
		spawnedPlayer = true;

	}

}
