using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFollowers : MonoBehaviour {

    public int newFollowers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Stats>().currentFollowers += newFollowers;
	}

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Temple")
        {
            newFollowers = Random.Range(1, 10);
        }
        else if(collision.tag == "Shrine")
        {
            newFollowers = Random.Range(1, 4);
        }
        if (newFollowers > 20)
            newFollowers = 20;
    }
}
