using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int kills, usedFollowers;
    public int playerHealth;
    public List<GameObject> followers;

    // Use this for initialization
    void Start () {
        kills = 0;
        usedFollowers = 0;
        playerHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {

    }

    public int getFollowerCount()
    {
        return followers.Count;
    }

    public void addFollower(GameObject follower)
    {
        followers.Add(follower);
    }

    public bool removeFollower()
    {
        if (followers.Count > 0)
        {
            followers[0].GetComponent<FollowerMoveScript>().destroyFollower();
            ++usedFollowers;
            return true;
        }
        return false;
    }

    public void removeFollower(GameObject follower)
    {
        followers.Remove(follower);
    }

    public bool removeTenFollowers()
    {
        return false;
    }
}
