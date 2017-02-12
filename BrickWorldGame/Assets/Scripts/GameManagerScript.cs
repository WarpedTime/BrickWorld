using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    private int score;
	public int Score{ get{ return score;} set{ score = value;}}


    [SerializeField] GameObject PlayerPrefab;
	[SerializeField] GameObject StartRoom;
    [SerializeField] float distancefromCamera;

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
						return;
		}

		score = 0;

		currentRoom = Instantiate (StartRoom, new Vector3 (distancefromCamera, 0, 0), Quaternion.identity);
		Transform StartP = GameObject.Find ("Start_Point").transform;
		player = Instantiate (PlayerPrefab, StartP.position, Quaternion.identity);

	}

	void enterDoor(GameObject door){
		if (isDebug) {
		} else {
		}

		//destroy previous room
		GameObject.Destroy (currentRoom);

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
		if (Input.GetKey(KeyCode.Escape)) {
			//Debug.Log ("D");
			SpawnPlayer();
		}

		if (!spawnedPlayer)
			SpawnPlayer ();

	}

	public void SpawnPlayer(){
		player.GetComponent<Playertest>().Spawn();
		spawnedPlayer = true;

	}

}
