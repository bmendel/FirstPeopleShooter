using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : ActorMoveScript {

    public bool aggrod, resting;

    protected override void Start()
    {
        target = GameObject.FindWithTag("Player");
        aggrod = false;
        resting = false;
        aggro_dist = 4.0f;
        sleep_dist = 6.0f;
        health = 20;
        damage = 10;
    }

    protected override void Update()
    {
        float dist = Vector3.Distance(target.transform.position,
                                      transform.position);

        if (!resting && (dist < aggro_dist || aggrod))
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

        if (c.gameObject.tag == "Follower")
        {
            c.gameObject.GetComponent<FollowerMoveScript>().destroyFollower();
        }

        if (c.gameObject.tag == "Bullet")
        {
            if (target.GetComponent<PlayerStats>().playerHealth < 99)
            {
                target.GetComponent<PlayerStats>().playerHealth += 2;
                Debug.Log(target.GetComponent<PlayerStats>().playerHealth);
            }
            Destroy(c.gameObject);
            Destroy(this.gameObject);
        }

        resting = true;
        Invoke("WakeUp", 0.75f);
    }

    void WakeUp()
    {
        resting = false;
    }

}
