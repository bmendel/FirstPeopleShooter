using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour {

    public GameObject enemy;
    public GameObject bullet;

	// Use this for initialization
	void Start () {

    }
	
	void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //GetComponent<EnemyWaveManager>().enemy_count--;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
