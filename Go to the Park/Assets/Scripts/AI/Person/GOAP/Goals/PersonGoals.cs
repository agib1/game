using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base goap goals for person ai, PersonGoals implements the Goals interface.
public interface Goals
{
    int CalculatePriority();
    bool GoalCanRun();
    void OnGoalRunning();
    void OnGoalActivated();
    void OnGoalDeactivated();

}

public class PersonGoals : MonoBehaviour, Goals
{
    void Update()
    {
        OnGoalRunning();
    }

    public virtual int CalculatePriority()
    {
        return -1;
    }
    public virtual bool GoalCanRun()
    {
        return false;
    }
    public virtual void OnGoalRunning()
    {

    }
    public virtual void OnGoalActivated()
    {

    }
    public virtual void OnGoalDeactivated(){

    }

}

