using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// goap idle goal for person ai, inherites PersonGoals
public class IdleGoal : PersonGoals
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

}
