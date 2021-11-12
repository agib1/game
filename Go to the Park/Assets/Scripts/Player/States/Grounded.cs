using UnityEngine;


//Class for being Grounded, part of heirachical state machine - inherited by Moving and Idle.
public class Grounded : PlayerBaseState
{
    protected PlayerStateManager sm;

    public Grounded(PlayerStateManager playerStateManager) : base(playerStateManager)
    {
        sm = (PlayerStateManager) this.playerStateManager;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        if (Input.GetKeyDown(KeyCode.Space))
            playerStateManager.ChangeState(sm.jumpingState);
    }

}
