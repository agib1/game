using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : BaseState
{
    private PlayerStateManager sm;
    private bool isGrounded;
    private float groundCheckDistance = 0.02f;
   
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
            stateManager.ChangeState(sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundLayer);
    }
}
