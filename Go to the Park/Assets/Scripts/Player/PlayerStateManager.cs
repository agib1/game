using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manager for the finite state machine for Player Movement. Using Rigidbody.
public class PlayerStateManager : PlayerStateMachine
{
    public float walkSpeed = 2f;
    public float maxSpeed = 6f;
    public float jumpForce = 5f;
    public bool isAccelerating = false;
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
    public Jumping jumpingState;

    private void Awake()
    {
        idleState = new Idle(this);
        walkingState = new Walking(this);
        jumpingState = new Jumping(this);


        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    protected override PlayerBaseState GetInitialState()
    {
        return idleState;
    }
}
