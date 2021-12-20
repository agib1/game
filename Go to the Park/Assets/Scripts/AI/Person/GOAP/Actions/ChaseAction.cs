using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//GOAP: Actions for chase ai, inherites PersonActions
public class ChaseAction : PersonActions
{
    List<System.Type> goals = new List<System.Type>(new System.Type[] {typeof(ChaseGoal)});
    public override List<System.Type> GetGoals()
    {
        return goals;
    }

    public override float Cost()
    {
        return 0f;
    }

    // if acivated, add person to angry flock.
    public virtual void OnActionActivated()
    {
        PersonFlocking flock = GameObject.Find("AngryFlock").GetComponent<PersonFlocking>();
        flock.AddToFlock(gameObject);
    }
}
