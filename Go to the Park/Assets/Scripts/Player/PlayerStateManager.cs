using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : PlayerStateMachine
{
    public float walkSpeed = 2f;
    public float runSpeed = 8f;
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
    public Running runningState;
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
        runningState = new Running(this);
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
