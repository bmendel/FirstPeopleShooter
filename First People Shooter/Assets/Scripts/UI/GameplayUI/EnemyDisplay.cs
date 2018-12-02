using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDisplay : MonoBehaviour {

    public Text enemyText;
    public int enemies;

	// Use this for initialization
	void Start () {
        enemies = 20;
	}
	
	// Update is called once per frame
	void Update () {
        enemyText.text = "Enemies: " + enemies;

        if(Input.GetKeyDown(KeyCode.R))
        {
            enemies--;
        }
	}
}
