using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

    public GameObject player;
    public Text healthText;
    public int health;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerStats>().getHealth();
        healthText.text = "Health : " + health;

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(health);
        }*/
    }
}
