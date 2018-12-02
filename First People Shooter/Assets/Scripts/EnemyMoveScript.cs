using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : ActorMoveScript {

    public bool aggrod;

    protected override void Start()
    {
        target = GameObject.FindWithTag("Player");
        aggrod = false;
        aggro_dist = 4.0f;
        sleep_dist = 6.0f;
        health = 20;
        damage = 10;
    }

    protected override void Update()
    {
        float dist = Vector3.Distance(target.transform.position,
                                      transform.position);

        if (dist < aggro_dist || aggrod)
        {
            aggrod = true;
            transform.LookAt(target.transform);
            Vector3 forward = transform.forward;
            transform.position += new Vector3(forward.x, 0, forward.z) * move_speed;
        }

        if (dist > sleep_dist && aggrod)
        {
            aggrod = false;
        }
    }

    protected void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            target.GetComponent<PlayerStats>().playerHealth -= damage;
            Debug.Log(target.GetComponent<PlayerStats>().playerHealth);
        }
    }

}
