using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Paths are set dynamically due to nature of person interaction (random)
//State for wandering, using AI state machine 
public class WanderAI: PersonBaseState
{
    protected PersonStateManager sm;

    public bool pointWaiting;
    public float switchProbability = 0.2f;

    public WanderAI (PersonStateManager personStateManager) : base(personStateManager)
    {
        sm = (PersonStateManager)this.personStateManager;
    }

    public override void Enter()
    {
        base.Enter();
        //Pathfinding: moving between nodes.
        if (sm.currentWaypoint == null)
        {
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

            if (allWaypoints.Length > 0)
            {
                while (sm.currentWaypoint == null)
                {
                    int random = UnityEngine.Random.Range(0, allWaypoints.Length);
                    PersonWaypoints startingWaypoint = allWaypoints[random].GetComponent<PersonWaypoints>();

                    if (startingWaypoint != null)
                    {
                        sm.currentWaypoint = startingWaypoint;
                    }
                }
            }
        }

        sm.SetDestination();
    }
  
    public override void Update()
    {
        base.Update();
        sm.anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        //Pathfinding: moving between nodes.
        if (sm.travelling && sm.nma.remainingDistance <= 1f)
        {
            sm.travelling = false;
            sm.waypointsVisited++;

            if (pointWaiting)
            {
                sm.waiting = true;
                sm.waitTimer = 0f;
            }
            else
            {
                sm.SetDestination();
            }

        }

        if (sm.waiting)
        {
            personStateManager.ChangeState(sm.idleState);
        }

    }
}
