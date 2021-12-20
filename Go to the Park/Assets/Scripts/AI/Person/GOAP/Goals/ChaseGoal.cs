using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// goap chase goal for person ai, inherites PersonGoals
public class ChaseGoal : PersonGoals
{
    int priority = 0;
    public override int CalculatePriority()
    {
        return priority;
    }

    public override bool GoalCanRun()
    {
        return true;
    }

    //On collision with player, the chase goal is actived.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            priority = 50;
        }
    }

}
