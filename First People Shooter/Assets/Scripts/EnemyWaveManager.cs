using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour {

    public GameObject[] spawns;
    public int wave_count;
    public int spawn_capacity, wave_capacity;
    public float time_to_next_wave;
    public bool initiate_next_wave;

	// Use this for initialization
	void Start () {
        wave_count = 0;
        spawn_capacity = 4; // number of enemies that can be on the field
        wave_capacity = 10; // number of enemies total in the wave
        StartNextWave();
        time_to_next_wave = 5.0f;
        initiate_next_wave = false;
	}
	
	// Update is called once per frame
	void Update () {
        // If the total number of enemies in the wave have spawned, 
        // disable spawning enemies for the rest of the round
        if (GetSpawnCount() >= wave_capacity)
        {
            DisableWaveSpawns();
            initiate_next_wave = true;
        }

        // If the enemy count is low, count down to the start of the next wave
		if (GetEnemyCount() < 5 && initiate_next_wave)
        {
            Invoke("StartNextWave", time_to_next_wave);
            initiate_next_wave = false;
        }
    }

    // Set up total enemy counts for the next wave
    void StartNextWave()
    {
        wave_count++;
        spawn_capacity += 4;
        wave_capacity += wave_capacity / 3;
        Debug.Log("Wave " + wave_count + ": spawn capacity=" + spawn_capacity + ", wave_capacity=" + wave_capacity);
        SetupWaveSpawns();
    }

    // Returns the total number of spawns across all enemy spawners in this wave
    int GetSpawnCount()
    {
        int count = 0;
        foreach (GameObject spawn in spawns)
        {
            count += spawn.GetComponent<EnemySpawnManager>().getSpawnCount();
        }
        return count;
    }

    // Returns the total number of enemies on the field at that instant
    public int GetEnemyCount()
    {
        int count = 0;
        foreach (GameObject spawn in spawns)
        {
            count += spawn.GetComponent<EnemySpawnManager>().spawned_actors.Count;
        }
        return count;
    }

    // Sets up spawner information for the next wave and enables them
    void SetupWaveSpawns()
    {
        foreach (GameObject spawn in spawns)
        {
            spawn.GetComponent<EnemySpawnManager>().setSpawnLimit(spawn_capacity / spawns.Length);
            spawn.GetComponent<EnemySpawnManager>().increaseEnemySpeed();
            spawn.GetComponent<EnemySpawnManager>().enableSpawns();
        }
    }

    // Disables spawners
    void DisableWaveSpawns()
    {
        foreach (GameObject spawn in spawns)
        {
            spawn.GetComponent<EnemySpawnManager>().disableSpawns();
            spawn.GetComponent<EnemySpawnManager>().resetSpawnCount();
        }
    }
}
