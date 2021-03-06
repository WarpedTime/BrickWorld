﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private GameManagerScript GM;
    [SerializeField]
    int points;
    // Use this for initialization
    void Start()
    {

        GM = GameObject.Find("GM").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GM.Score += points;
        }
    }
}