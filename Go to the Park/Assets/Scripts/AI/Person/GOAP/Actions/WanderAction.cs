using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Goap action for person ai wondering. uses pathfinding points in personwaypoints to wander through track.
public class WanderAction : PersonActions
{
    List<System.Type> goals = new List<System.Type>(new System.Type[] {typeof(WanderGoal)});

    public override List<System.Type> GetGoals()
    {
        return goals;
    }

    public override float Cost()
    {
        return 0f;
    }

    public override void OnActionRunning()
    {
        base.anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        //Pathfinding: moving between nodes.
        if (base.nma.remainingDistance <= 1f)
        {
            waypointsVisited++;

            base.SetDestination();
        }
    }
    public override void OnActionActivated()
    {
        base.Start();
        //Pathfinding: moving between nodes.
        //Paths are set dynamically due to nature of person interaction (random wandering)
        if (base.currentWaypoint == null)
        {
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

            if (allWaypoints.Length > 0)
            {
                while (base.currentWaypoint == null)
                {
                    int random = UnityEngine.Random.Range(0, allWaypoints.Length);
                    PersonWaypoints startingWaypoint = allWaypoints[random].GetComponent<PersonWaypoints>();

                    if (startingWaypoint != null)
                    {
                        base.currentWaypoint = startingWaypoint;
                    }
                }
            }
        }

        base.SetDestination();
    }
}