using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//State for acceleration, using rigidbody physics. uses heirachical state machine - inherites the Moving class
// public class Accelerating : Moving
// {
// //     private float acceleration;
// //     private float timeToMax = 2.5f;
// //     private float currentVelocity;

//     // public Accelerating(PlayerStateManager playerStateManager) : base(playerStateManager)
//     // {
//     //     sm = (PlayerStateManager)this.playerStateManager;
//     //}

// //     public override void Enter()
// //     {
// //         base.Enter();

// //         acceleration = sm.maxSpeed / timeToMax;

// //         currentVelocity = 0f;
// //     }

// //     public override void UpdatePhysics()
// //     {
// //         base.UpdatePhysics();

// //         sm.anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);

// //         currentVelocity = acceleration * Time.deltaTime;
// //         currentVelocity = Mathf.Min(currentVelocity, sm.maxSpeed);

// //         sm.rb.velocity = moveDirection * currentVelocity;
// //     }
// }
