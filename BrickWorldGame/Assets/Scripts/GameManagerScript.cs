using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {


    private int score;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    float distancefromCamera;
    private Transform StartP,EndP;
	// Use this for initialization
	void Start (){
        DontDestroyOnLoad(this.gameObject);
        score = 0;
        GameObject Level = Resources.Load("Level1") as GameObject;
        Instantiate(Level, new Vector3(distancefromCamera,0,0), Quaternion.identity);
        StartP = GameObject.Find("Start_Point").GetComponent<Transform>();
        EndP = GameObject.Find("End_Point").GetComponent<Transform>();
        Instantiate(Player, StartP.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
