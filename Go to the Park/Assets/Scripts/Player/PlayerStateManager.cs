using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manager for the finite state machine for Player Movement. Using Rigidbody physics.
public class PlayerStateManager : PlayerStateMachine
{
    public float walkSpeed = 2f;
    public float maxSpeed = 6f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public Animator anim;

    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Walking walkingState;
    [HideInInspector]
    public Accelerating acceleratingState;
    [HideInInspector]
    public Jumping jumpingState;
    // [HideInInspector]
    // public Skidding skiddingState;
    // [HideInInspector]
    // public Trudging trudgingState;

    private void Awake()
    {
        idleState = new Idle(this);
        walkingState = new Walking(this);
        acceleratingState = new Accelerating(this);
        jumpingState = new Jumping(this);
        // skiddingState = new Skidding(this);
        // trudgingState = new Trudging(this);

        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    protected override PlayerBaseState GetInitialState()
    {
        return idleState;
    }
}
