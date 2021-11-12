using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
