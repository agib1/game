using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//State for walking, using rigidbody physics. uses heirachical state machine - inherites the Moving class
public class Walking : Moving
{
    public Walking(PlayerStateManager playerStateManager) : base(playerStateManager)
    {
        sm = (PlayerStateManager)this.playerStateManager;
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        sm.anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        
        sm.rb.velocity = moveDirection * ((PlayerStateManager)sm).walkSpeed;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            playerStateManager.ChangeState(sm.acceleratingState);
        }
    }
}
