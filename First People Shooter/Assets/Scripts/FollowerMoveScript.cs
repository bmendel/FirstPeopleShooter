using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMoveScript : ActorMoveScript {

    public bool following;

    protected override void Start()
    {
        target = GameObject.FindWithTag("Player");
        following = false;
        aggro_dist = 3.0f;
        sleep_dist = 10.0f;
    }

    protected override void Update()
    {
        float dist = Vector3.Distance(target.transform.position,
                                      transform.position);

        if (dist < aggro_dist || following)
        {
            if (!following)
            {
                target.GetComponent<PlayerStats>().addFollower(this.gameObject);
            }
            following = true;
            transform.LookAt(target.transform);
            Vector3 forward = transform.forward;
            transform.position += new Vector3(forward.x, 0, forward.z) * move_speed;
        }

        if (dist > sleep_dist && following)
        {
            if (following)
            {
                target.GetComponent<PlayerStats>().removeFollower(this.gameObject);
            }
            following = false;
        }
    }

}
