using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {


    private int score;
    [SerializeField]
    GameObject PlayerSpawnObj;
    [SerializeField]
    float distancefromCamera;
    private Transform StartP,EndP;
    private GameObject Player;
	// Use this for initialization
	void Start (){
        DontDestroyOnLoad(this.gameObject);
        score = 0;
        //load in the level
        GameObject Level = Resources.Load("Level1test") as GameObject;
        Instantiate(Level, new Vector3(distancefromCamera,0,0), Quaternion.identity);
        //find the start and end point
        StartP = GameObject.Find("Start_Point").GetComponent<Transform>();
        EndP = GameObject.Find("End_Point").GetComponent<Transform>();
        //put the player at this location
        Instantiate(PlayerSpawnObj, StartP.position, Quaternion.identity);
        //grab the player into the field
        Player = GameObject.Find("PlayerTest(Clone)");
    }
	
	// Update is called once per frame
	void Update () {
        
        Camera.main.transform.position = new Vector3(Player.transform.position.x + 20.0f, Player.transform.position.y, Player.transform.position.z);

	}

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public float DistancefromCamera
    {
        get
        {
            return distancefromCamera;
        }
    }
}
