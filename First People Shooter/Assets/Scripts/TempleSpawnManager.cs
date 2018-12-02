using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleSpawnManager : ActorSpawnManager {

    public float allegiance;
    public int capacity;  
    public GameObject[] waiting_actors;

    // Use this for initialization
    protected override void Start()
    {
        capacity = 4;
        waiting_actors = new GameObject[capacity];
        spawn_time = 10;
        spawn_limit = 20;
        InvokeRepeating("Spawn", spawn_time, spawn_time);
    }

    protected override void Update()
    {
        // Check to see if waiting followers have moved from their spawned position
        for (int i = 0; i < waiting_actors.Length; ++i) {
            if (waiting_actors[i] && waiting_actors[i].GetComponent<FollowerMoveScript>().following)
            {
                waiting_actors[i] = null;
            }
        }
    }

    protected override void Spawn()
    {
        for (int i = 0; i < spawnpoints.Length; ++i)
        {
            if (!waiting_actors[i] && spawned_actors.Count < spawn_limit)
            {
                GameObject follower = Instantiate(actor, spawnpoints[i].position, spawnpoints[i].rotation);
                spawned_actors.Add(follower);
                waiting_actors[i] = follower;
            }
        }
    }
}
