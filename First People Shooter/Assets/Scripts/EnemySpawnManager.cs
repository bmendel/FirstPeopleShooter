using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spawnpoints;
    public float spawn_time;

    // Use this for initialization
    void Start () {
        InvokeRepeating("spawnEnemy", spawn_time, spawn_time);
	}

    void spawnEnemy()
    {
        foreach (Transform spawn in spawnpoints)
        {
            Instantiate(enemy, spawn.position, spawn.rotation);
        }
        
    }
}
