using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdStateManager : EnemiesStateManager
{
    public override void Start()
    {
        CurrentState = State.BirdIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
        FlipXObjectIfSeeGround();
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            CurrentState = State.BirdGotHit();
            CurrentState.EnterState();
        }
    }
}
