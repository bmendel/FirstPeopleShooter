﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public int Influence;
    public int currentFollowers;
    public int usedFollowers;
    public int playerHealth;
    public int ownedTemples;
    public List<GameObject> Followers;

    // Use this for initialization
    void Start () {
        playerHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
        Influence = currentFollowers - usedFollowers;
    }

    public void getFollower(GameObject follower)
    {
        Followers.Add(follower);
        currentFollowers += 1;
    }
}
