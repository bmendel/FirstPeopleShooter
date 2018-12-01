using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : ActorSpawnManager {

    // Use this for initialization
    protected override void Start () {
        spawn_time = 5;
        spawn_limit = 20;
        InvokeRepeating("Spawn", spawn_time, spawn_time);
	}

    protected override void Update()
    {

    }

    protected override void Spawn()
    {
        foreach (Transform spawn in spawnpoints)
        {
            if (spawned_actors.Count < spawn_limit)
            {
                Instantiate(actor, spawn.position, spawn.rotation);
            }
        }
    }
}
