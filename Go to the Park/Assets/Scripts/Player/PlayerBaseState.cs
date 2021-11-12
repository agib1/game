using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : MonoBehaviour
{
    protected PlayerStateManager playerStateManager;
    public PlayerBaseState(PlayerStateManager playerStateManager)
    {
        this.playerStateManager = playerStateManager;
    }
    public virtual void Enter() {}
    public virtual void UpdateLogic() {}
    public virtual void UpdatePhysics() {}
    public virtual void Exit() {}
}
