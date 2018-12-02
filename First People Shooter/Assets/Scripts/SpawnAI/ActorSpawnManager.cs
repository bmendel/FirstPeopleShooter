using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorSpawnManager : MonoBehaviour {

    public GameObject actor;
    public List<GameObject> spawned_actors;
    public Transform[] spawnpoints;
    public float spawn_time;
    public int spawn_limit;

    // Use this for initialization
    protected abstract void Start();

    protected abstract void Update();

    protected abstract void Spawn();
}
