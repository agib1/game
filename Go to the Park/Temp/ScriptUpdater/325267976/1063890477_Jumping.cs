using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : BaseState
{
    private PlayerStateManager sm;
    private bool isGrounded;
   
    public Jumping(PlayerStateManager stateManager) : base(stateManager)
    {
        sm = (PlayerStateManager)this.stateManager;
    }

    public override void Enter()
    {
        base.Enter();

        Vector3 velocity = sm.GetComponent<Rigidbody>().velocity;
        velocity.y += sm.jumpForce;
        sm.rb.velocity = velocity;
        // sm.rb.AddForce(Vector3.up * sm.jumpForce, ForceMode.Impulse);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (isGrounded)
        {
            sm.ChangeState(sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        isGrounded = sm.GetComponent<Rigidbody>().velocity.y < Mathf.Epsilon && sm.rb.IsTouchingLayers(sm.groundLayer);
    }
}
