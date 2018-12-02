using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int Influence;
    //public int usedFollowers;
    public int playerHealth;
    public int ownedTemples;
    public List<GameObject> followers;

    // Use this for initialization
    void Start () {
        playerHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
        Influence = followers.Count;// - usedFollowers;
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
