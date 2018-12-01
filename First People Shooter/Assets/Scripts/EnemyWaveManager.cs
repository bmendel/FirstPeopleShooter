using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour {

    public GameObject[] spawns;
    public int wave_count;
    public int enemy_count, enemy_capacity;
    public float time_to_next_wave;
    public bool initiate_next_wave;

	// Use this for initialization
	void Start () {
        wave_count = 1;
        enemy_count = 0;
        enemy_capacity = 20;
        SetupWaveSpawns();
        time_to_next_wave = 2.0f;
        initiate_next_wave = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy_count < 5 && !initiate_next_wave)
        {
            Invoke("StartNextWave", time_to_next_wave);
            initiate_next_wave = true;
        }

        enemy_count = GetEnemyCount();
        Debug.Log(enemy_count);
    }

    void StartNextWave()
    {
        wave_count++;
        enemy_capacity += enemy_capacity / 4;
        SetupWaveSpawns();
        initiate_next_wave = false;
    }

    int GetEnemyCount()
    {
        int count = 0;
        foreach (GameObject spawn in spawns)
        {
            count += spawn.GetComponent<EnemySpawnManager>().getSpawnCount();
        }
        return count;
    }

    void SetupWaveSpawns()
    {
        foreach (GameObject spawn in spawns)
        {
            spawn.GetComponent<EnemySpawnManager>().setSpawnLimit(enemy_capacity / spawns.Length);
            spawn.GetComponent<EnemySpawnManager>().enableSpawns();
        }
    }
}
