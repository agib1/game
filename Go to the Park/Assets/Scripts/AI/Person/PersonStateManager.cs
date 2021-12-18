using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Manager for the finite state machine for Player Movement. Using Rigidbody.
public class PersonStateManager : PersonStateMachine
{
    public IdleAI idleState;
    public WanderAI wanderState;

    [HideInInspector]
    public Animator anim;
    public NavMeshAgent nma;
    public PersonWaypoints currentWaypoint;
    public PersonWaypoints previousWaypoint;

    public int waypointsVisited;


    public bool travelling;
    public bool waiting;
    public float waitTimer;

    private void Awake()
    {
        idleState = new IdleAI(this);
        wanderState = new WanderAI(this);
        anim = GetComponentInChildren<Animator>();
        nma = this.GetComponent<NavMeshAgent>();
    }

    protected override PersonBaseState GetInitialState()
    {
        return wanderState;
    }

    public void SetDestination()
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
