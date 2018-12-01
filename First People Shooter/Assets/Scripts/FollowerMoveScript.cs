using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMoveScript : ActorMoveScript {

    public float health, damage;

    protected override void Start()
    {
        base.Start();
        base.aggro_dist = 3.0f;
        base.sleep_dist = 10.0f;
    }

    protected override void Update()
    {
        base.Update();
    }
}
