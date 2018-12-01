using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : ActorMoveScript {

    public float health, damage;

    protected override void Start()
    {
        base.Start();
        base.aggro_dist = 4.0f;
        base.sleep_dist = 6.0f;
    }

    protected override void Update()
    {
        base.Update();
    }

}
