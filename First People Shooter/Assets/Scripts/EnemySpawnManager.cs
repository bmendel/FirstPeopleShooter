using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : ActorSpawnManager {

    public bool allow_spawning;
    public int total_spawns;
    public float speed;

    // Use this for initialization
    protected override void Start ()
    {
        speed = 0.8f;
        total_spawns = 0;
        spawn_time = 5;
        spawn_limit = 20;
        allow_spawning = false;
        InvokeRepeating("Spawn", 5.0f, spawn_time);
    }

    protected override void Update()
    {
        // Check to see if any spawned actors are null (have been destroyed)
        // and removes them from the list
        for (int i = 0; i < spawned_actors.Count; ++i)
        {
            if (!spawned_actors[i])
            {
                spawned_actors.RemoveAt(i);
            }
        }
    }

    protected override void Spawn()
    {
        foreach (Transform spawn in spawnpoints)
        {
            if (allow_spawning && spawned_actors.Count < spawn_limit)
            {
                GameObject enemy = Instantiate(actor, spawn.position, spawn.rotation);
                enemy.GetComponent<EnemyMoveScript>().SetSpeed(speed);
                spawned_actors.Add(enemy);
                total_spawns++;
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
        return total_spawns;
    }

    public void resetSpawnCount()
    {
        total_spawns = 0;
    }

    public void increaseEnemySpeed()
    {
        speed += 0.1f;
    }
}
