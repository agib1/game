using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//State for idle, using AI state machine 
public class IdleAI : PersonBaseState
{
    private PersonStateManager sm;

    public float waitTime = 3f;

    public IdleAI (PersonStateManager personStateManager) : base(personStateManager)
    {
        sm = (PersonStateManager)this.personStateManager;
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Update()
    {
        base.Update();

        sm.anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);

        //Path finding: moving to next node

        sm.waitTimer += Time.deltaTime;

        if (sm.waitTimer > waitTime)
        {
            sm.waiting = false;

            sm.SetDestination();

            personStateManager.ChangeState(sm.wanderState);
        }
    }

}
