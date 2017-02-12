using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    private int score;
	public int Score{ get{ return score;} set{ score = value;}}


    [SerializeField] GameObject PlayerPrefab;
	[SerializeField] GameObject RoomPrefab;
    [SerializeField] float distancefromCamera;

	public GameObject currentRoom;
	public GameObject player;
	public int roomNum=0;

	[SerializeField] bool isDebug;
	[SerializeField] GameObject d_CurerntRoom;
	[SerializeField] GameObject d_Player;

	bool spawnedPlayer = false;
	bool spawnedRoom = false;

	// Use this for initialization
	void Start (){
		DontDestroyOnLoad (this.gameObject);

		if (isDebug) {
    
			score = 0;
        	
			currentRoom = d_CurerntRoom;
			player = d_Player;
			PlayerPrefab = player;
			spawnedRoom = true;
			spawnedPlayer = false;
			return;
		}

		score = 0;

		currentRoom = Instantiate (RoomPrefab, new Vector3 (distancefromCamera, 0, 0), Quaternion.identity);
		Transform StartP = GameObject.Find ("*").transform;
		player = Instantiate (PlayerPrefab, StartP.position, Quaternion.identity);
	}

	void enterDoor(GameObject door){
		spawnedRoom = false;
		RoomPrefab = door.GetComponent<DoorScript> ().NextRoom;
		player.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape)) {
			//Debug.Log ("D");
			SpawnPlayer();
		}

		if (!spawnedRoom) {
			//destroy previous room
			GameObject.Destroy(currentRoom);

			//increase visited room count
			roomNum++;

			//get next room
			Debug.Log ("Entering "+ RoomPrefab.name);

			//create new room
			currentRoom = Instantiate (RoomPrefab, new Vector3 (distancefromCamera, 0, 0), Quaternion.identity);
			currentRoom.name += " [" + roomNum + "]";

			//setup and spawn player
			spawnedPlayer=false;

			spawnedRoom = true;
		}


		if (!spawnedPlayer && currentRoom.GetComponent<RoomScript>().roomReady) {
			Debug.Log ("Entered Room "+roomNum);
			SpawnPlayer ();
		}

	}

	public void SpawnPlayer(){
		player.SetActive (true);
		player.GetComponent<Playertest>().Spawn();
		player.name = "player " + roomNum;
		spawnedPlayer = true;
	}

}
