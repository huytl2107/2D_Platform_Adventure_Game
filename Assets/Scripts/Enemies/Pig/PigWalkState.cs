using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigWalkState : EnemiesWalkState
{
    public PigWalkState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Anim.SetInteger("State", (int)StateEnum.EPigState.walk);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        CheckSwitchState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(enemy.SeePlayer)
        {
            SwitchState(factory.PigAttack());
        }
    }


}
