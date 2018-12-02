using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDisplay : MonoBehaviour {

    public GameObject player;
    public GameObject enemyWaveController;
    public Text enemyText, waveText;
    public int enemies, enemiesKilled;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        enemyWaveController = GameObject.FindWithTag("SpawnControl");
	}
	
	// Update is called once per frame
	void Update () {
        enemiesKilled = player.GetComponent<PlayerStats>().getWaveKillCount();
        enemies = enemyWaveController.GetComponent<EnemyWaveManager>().wave_capacity;
        waveText.text = "Wave: " + enemyWaveController.GetComponent<EnemyWaveManager>().wave_count;
        if (enemiesKilled >= enemies)
        {
            enemyText.text = "Wave Complete!";
        }
        else
        {
            enemyText.text = "Enemies Killed: " + enemiesKilled + "/" + enemies;
        }

        /*if(Input.GetKeyDown(KeyCode.R))
        {
            enemies--;
        }*/
	}
}
