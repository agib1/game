using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Grounded
{
    private PlayerStateManager sm;

    public Idle (PlayerStateManager playerStateManager) : base(playerStateManager)
    {
        sm = (PlayerStateManager)this.playerStateManager;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        sm.anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerStateManager.ChangeState(sm.walkingState);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.RightShift))
        {
            playerStateManager.ChangeState(sm.runningState);
        }
    }
}
