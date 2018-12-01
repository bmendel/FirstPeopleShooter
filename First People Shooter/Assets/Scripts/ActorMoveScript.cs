using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMoveScript : MonoBehaviour {

    GameObject target;
    public bool aggrod;
    public float aggro_dist, sleep_dist;
    public float move_speed;
    //public float health, damage;

    // Use this for initialization
    protected virtual void Start()
    {
        target = GameObject.FindWithTag("Player");
        aggrod = false;
    }

    // Update is called once per frame
    protected virtual void Update()
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
}
