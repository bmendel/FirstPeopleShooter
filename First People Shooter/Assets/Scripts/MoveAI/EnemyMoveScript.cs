using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : ActorMoveScript {

    public bool resting;
    public float speed;
    public int hits, total_hits;

    protected override void Start()
    {
        target = GameObject.FindWithTag("Player");
        health = 20;
        damage = 10;
        speed = 0.8f;
        hits = 0;
        total_hits = 3;
    }

    protected override void Update()
    {
        float dist = Vector3.Distance(target.transform.position,
                                      transform.position);

        

        if (!resting)
        {
            // If enemy hits player, player takes damage
            if (dist < 1.0f)
            {
                target.GetComponent<PlayerStats>().playerHealth -= damage;
                resting = true;
                Invoke("WakeUp", 1.0f);
            }
            transform.LookAt(target.transform);
            Vector3 forward = transform.forward;
            transform.position += new Vector3(speed * forward.x, 0, speed * forward.z) * move_speed;
        }
        // After a hit, the enemy "rests" for a bit (doesn't move)
        
    }

    // Checks for collisions against other actors in the world
    protected void OnCollisionEnter(Collision c)
    {
        // If enemy hits a follower, the follower is destroyed
        if (c.gameObject.tag == "Follower")
        {
            c.gameObject.GetComponent<FollowerMoveScript>().destroyFollower();
            hits++;
            if (hits >= total_hits)
            {
                destroyEnemy();
            }
            resting = true;
            Invoke("WakeUp", 1.0f);
        }

        // If enemy hits a bullet, the enemy is destroyed and the player gets some life
        if (c.gameObject.tag == "Bullet")
        {
            Destroy(c.gameObject);
            destroyEnemy();
        }
    }

    void destroyEnemy()
    {
        if (target.GetComponent<PlayerStats>().playerHealth < 100)
        {
            target.GetComponent<PlayerStats>().playerHealth += 2;
        }
        target.GetComponent<PlayerStats>().addKill();
        Destroy(this.gameObject);
    }

    // Called to "wake up" an enemy resting after a collision
    // Collisions cause the enemy to move slightly faster
    void WakeUp()
    {
        speed += 0.1f;
        resting = false;
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }
}
