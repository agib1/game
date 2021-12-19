using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseGoal : PersonGoals
{
    int priority = 10;
    public override int CalculatePriority()
    {
        return priority;
    }
    public override bool GoalCanRun()
    {
        return true;
    }

    public override void OnGoalActivated()
    {
    }

}
