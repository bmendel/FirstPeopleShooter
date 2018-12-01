using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public int Influence;
    public int currentFollowers;
    public int usedFollowers;
    public int playerHealth;
    public int ownedTemples;
    int newFollowers;

    // Use this for initialization
    void Start () {
        playerHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
        Influence = currentFollowers - usedFollowers;
    }

    private void onTriggerEnter(Collider collision)
    {
        Debug.Log("Collided");
        if (collision.tag == "Temple")
        {
            newFollowers = Random.Range(1, 10);
            Debug.Log("In temple.");
        }
        else if (collision.tag == "Shrine")
        {
            newFollowers = Random.Range(1, 4);
            Debug.Log("In shrine");
        }
        if (currentFollowers + newFollowers > 20)
        {
            currentFollowers = 20;
            Debug.Log(currentFollowers);
        }
        else
        {
            currentFollowers += newFollowers;
            Debug.Log(currentFollowers);
        }
    }
}
