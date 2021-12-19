using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//State for Jumping, using rigidbody physics. opposite of grounded
public class Jumping : PlayerBaseState
{
    private PlayerStateManager sm;
    private bool isGrounded;
    private float groundCheckDistance = 0.02f;
   
    public Jumping(PlayerStateManager playerStateManager) : base(playerStateManager)
    {
        sm = (PlayerStateManager)this.playerStateManager;
    }

    public override void Enter()
    {
        base.Enter();
        FindObjectOfType<AudioManager>().Play("Jump");

        Vector3 velocity = sm.GetComponent<Rigidbody>().velocity;
        velocity.y += sm.jumpForce;
        sm.rb.velocity = velocity;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (isGrounded)
        {
            playerStateManager.ChangeState(sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        isGrounded = Physics.CheckSphere(sm.rb.transform.position, groundCheckDistance, sm.groundLayer);
    }
}
