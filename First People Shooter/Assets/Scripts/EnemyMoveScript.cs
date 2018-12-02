using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : ActorMoveScript {

    public bool resting;
    float speed;

    protected override void Start()
    {
        target = GameObject.FindWithTag("Player");
        health = 20;
        damage = 10;
        speed = 0.8f;
    }

    protected override void Update()
    {
        float dist = Vector3.Distance(target.transform.position,
                                      transform.position);

        if (!resting)
        {
            transform.LookAt(target.transform);
            Vector3 forward = transform.forward;
            transform.position += new Vector3(speed * forward.x, 0, speed * forward.z) * move_speed;
        }
    }

    // Checks for collisions against other actors in the world
    protected void OnCollisionEnter(Collision c)
    {
        // If enemy hits player, player takes damage
        if (c.gameObject.tag == "Player")
        {
            target.GetComponent<PlayerStats>().playerHealth -= damage;
        }

        // If enemy hits a follower, the follower is destroyed
        if (c.gameObject.tag == "Follower")
        {
            c.gameObject.GetComponent<FollowerMoveScript>().destroyFollower();
        }

        // If enemy hits a bullet, the enemy is destroyed and the player gets some life
        if (c.gameObject.tag == "Bullet")
        {
            if (target.GetComponent<PlayerStats>().playerHealth < 100)
            {
                target.GetComponent<PlayerStats>().playerHealth += 2;
            }
            target.GetComponent<PlayerStats>().kills++;
            Destroy(c.gameObject);
            Destroy(this.gameObject);
        }

        // After a hit, the enemy "rests" for a bit (doesn't move)
        resting = true;
        Invoke("WakeUp", 0.75f);
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
