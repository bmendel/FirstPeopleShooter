using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {

    GameObject target;
    public float aggro_dist;
    public float move_speed;
    //public float health, damage;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(target.transform.position,
                                      transform.position);

        if (dist < aggro_dist)
        {
            transform.LookAt(target.transform);
            transform.position += transform.forward * move_speed;
        }
	}
}
