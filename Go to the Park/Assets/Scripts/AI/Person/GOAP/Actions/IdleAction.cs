using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//State for idle, using AI state machine 
public class IdleAction : PersonActions
{
    List<System.Type> goals = new List<System.Type>(new System.Type[] {typeof(IdleGoal)});
    
    public override List<System.Type> GetGoals()
    {
        return goals;
    }

    public override float Cost()
    {
        return 0f;
    }

    public virtual void OnActionRunning()
    {
        base.anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);

        base.SetDestination();
  
    }
    
    public override void OnActionActivated()
    {
        base.Start();
    }
 
}
