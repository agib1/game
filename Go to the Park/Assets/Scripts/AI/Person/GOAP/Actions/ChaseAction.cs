using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAction : PersonActions
{
    List<System.Type> goals = new List<System.Type>(new System.Type[] {typeof(ChaseGoal)});
    public override List<System.Type> GetGoals()
    {
        return goals;
    }

}
