using UnityEngine;

public class PlayerWallSlideState : PlayerBaseState
{
    public PlayerWallSlideState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void EnterState()
    {
        //Đặt velocity.x = 0 để hạn chế bug Dash xuyên tường
        player.Rb.velocity = new Vector2(0f, player.Rb.velocity.y);
        player.Anim.SetInteger("State", (int)StateEnum.EPlayerState.wallSlide);
    }
    
    public override void UpdateState()
    {
        CheckSwitchState();
    }

    public override void FixedUpdateState()
    {
        player.Rb.velocity = new Vector2(0f, player.Rb.velocity.y / 2.5f);
    }

    public override void CheckSwitchState()
    {
        if ((InputManager.Instant.Right() && player.RaycastDirX < 0) || (InputManager.Instant.Left() && player.RaycastDirX > 0))
        {
            SwitchState(factory.Fall());
        }
        else if (InputManager.Instant.Jump())
        {
            SwitchState(factory.WallJump());
        }
        else if(!player.IsSeeingGround)
        {
            SwitchState(factory.Fall());
        }
    }

    public override void ExitState()
    {

    }
}
