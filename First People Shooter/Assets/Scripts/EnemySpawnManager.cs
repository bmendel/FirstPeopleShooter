using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : ActorSpawnManager {

    public bool allow_spawning;

    // Use this for initialization
    protected override void Start ()
    {
        spawn_time = 5;
        spawn_limit = 20;
        allow_spawning = false;
        InvokeRepeating("Spawn", 1.0f, spawn_time);
    }

    protected override void Update()
    {

    }

    protected override void Spawn()
    {
        foreach (Transform spawn in spawnpoints)
        {
            if (allow_spawning && spawned_actors.Count < spawn_limit)
            {
                spawned_actors.Add(Instantiate(actor, spawn.position, spawn.rotation));
            }
        }
    }

    public void enableSpawns()
    {
        allow_spawning = true;
    }

    public void disableSpawns()
    {
        allow_spawning = false;
    }

    public void setSpawnLimit(int limit)
    {
        spawn_limit = limit;
    }

    public int getSpawnCount()
    {
        return spawned_actors.Count;
    }
}
