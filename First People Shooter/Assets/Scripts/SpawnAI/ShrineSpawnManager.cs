using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineSpawnManager : ActorSpawnManager {

    // Use this for initialization
    protected override void Start()
    {
        spawn_time = 5.0f;
        spawn_limit = 4;
        Invoke("Spawn", spawn_time);
    }

    protected override void Update()
    {

    }

    protected override void Spawn()
    { 
        for (int i = 0; i < spawnpoints.Length; ++i)
        {
            if (spawned_actors.Count < spawn_limit)
            {
                GameObject follower = Instantiate(actor, spawnpoints[i].position, spawnpoints[i].rotation);
                spawned_actors.Add(follower);
            }
        }
    }
}
