using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorMoveScript : MonoBehaviour {

    public GameObject target;
    public float aggro_dist, sleep_dist;
    public float move_speed;
    public int health, damage;

    // Use this for initialization
    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();
}
