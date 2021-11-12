using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : Grounded
{
    protected PlayerStateManager sm;
    protected float vertical;
    protected Vector3 moveDirection;

    public Moving(PlayerStateManager playerStateManager) : base(playerStateManager)
    {
        sm = (PlayerStateManager) this.playerStateManager;
    }

    public override void Enter()
    {
        base.Enter();
        vertical = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.RightShift))
        {
            playerStateManager.ChangeState(sm.idleState);    
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, vertical);
        moveDirection = sm.rb.transform.TransformDirection(moveDirection);
    }

}
