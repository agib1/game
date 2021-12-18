using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manager for the finite state machine for Player Movement. Using Rigidbody.
public class PersonStateManager : PersonStateMachine
{
    public IdleAI idleState;
    public WalkingAI walkingState;

    [HideInInspector]
    public Animator anim;
    public UnityEngine.AI.NavMeshAgent nma;


    public bool travelling;
    public bool waiting;
    public float waitTimer;

    private void Awake()
    {
        idleState = new IdleAI(this);
        walkingState = new WalkingAI(this);
        anim = GetComponentInChildren<Animator>();
        nma = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    protected override PersonBaseState GetInitialState()
    {
        return idleState;
    }

    private void SetDestination()
    {
        if (waypointsVisited > 0)
        {
            PersonWaypoints nextWaypoint = currentWaypoint.NextWaypoint(previousWaypoint);
            previousWaypoint = currentWaypoint;
            currentWaypoint = nextWaypoint;
        }

        Vector3 targetVector = currentWaypoint.transform.position;
        nma.SetDestination(targetVector);
        travelling = true;

    }
}
