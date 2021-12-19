using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// goap goals for wander ai
public class WanderGoal: PersonGoals
{
    int priority = 30;
    public override int CalculatePriority()
    {
        return priority;
    }
    public override bool GoalCanRun()
    {
        return true;
    }
}
