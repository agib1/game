using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : Moving
{
    public Running(PlayerStateManager playerStateManager) : base(playerStateManager)
    {
        sm = (PlayerStateManager)this.playerStateManager;
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        sm.anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        
        sm.rb.velocity = moveDirection * ((PlayerStateManager)sm).runSpeed;
    }
}
