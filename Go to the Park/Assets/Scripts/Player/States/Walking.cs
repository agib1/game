using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//State for walking, using rigidbody physics. uses heirachical state machine - inherites the Moving class
public class Walking : Moving
{

    private float acceleration;
    private float timeToMax = 500f;
    private float currentVelocity;
    public Walking(PlayerStateManager playerStateManager) : base(playerStateManager)
    {
        sm = (PlayerStateManager)this.playerStateManager;
    }

    private void InitializeAcceleration()
    {
        acceleration = sm.maxSpeed / timeToMax;

        currentVelocity = sm.walkSpeed;
    }

    public override void Enter()
    {
        base.Enter();
        FindObjectOfType<AudioManager>().Play("Walking");

        InitializeAcceleration();
    }

    //Postive Feedback Loop: Can choose to accelerate by pressing shift, player will go faster and complete level quicker, 
    //but is more likely to run into AI elements and loose energy. Can also walk and be slower, might not get there in time limit.
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        sm.anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        
        float speedFactor = sm.walkSpeed;

        if (Input.GetKey(KeyCode.RightShift))
        {
            sm.isAccelerating = true;
            sm.anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);

            currentVelocity += acceleration * sm.walkSpeed;
            currentVelocity = Mathf.Min(currentVelocity, sm.maxSpeed);

            speedFactor = currentVelocity;
        }

        sm.rb.velocity = moveDirection * speedFactor;
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Puddle"))
    //     {
    //         sm.anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);


    //         //stop timer, get time
    //         //pass to LevelSelector
    //     }
    // }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }
}
