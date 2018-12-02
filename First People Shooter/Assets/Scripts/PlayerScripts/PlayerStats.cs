using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public int kills, waveKills, usedFollowers;
    public int playerHealth;
    public List<GameObject> followers;
    public bool game_over;

    // Use this for initialization
    void Start () {
        kills = 0;
        waveKills = 0;
        usedFollowers = 0;
        playerHealth = 100;
        game_over = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth <= 0 && !game_over)
        {
            game_over = true;
            Invoke("endGame", 5.0f);
            GetComponent<PlayerControllerScript>().Pause();
        }
    }

    public void endGame()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

    public int getHealth()
    {
        return playerHealth;
    }

    public int getFollowerCount()
    {
        return followers.Count;
    }

    public void addKill()
    {
        kills++;
        waveKills++;
    }

    public int getKillCount()
    {
        return kills;
    }

    public int getWaveKillCount()
    {
        return waveKills;
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

    public void resetWaveKills()
    {
        waveKills = 0;
    }
}
