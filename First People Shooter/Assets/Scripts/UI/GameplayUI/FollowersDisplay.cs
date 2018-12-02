using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowersDisplay : MonoBehaviour
{

    public GameObject player;
    public Text followersText;
    public int followers;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
        followers = player.GetComponent<PlayerStats>().getFollowerCount();
        followersText.text = "Followers: " + followers;

        /*if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(followers);
        }*/
    }
}
