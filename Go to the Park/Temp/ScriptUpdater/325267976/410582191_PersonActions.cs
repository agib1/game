using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Actions
{
    void Awake();
    System.Type GetGoals();
    float Cost();
    void OnActionCompleted();
    void OnActionActivated();
    void OnActionDeactivate();

}

public class PersonActions : MonoBehaviour, Actions
{
    public Animator anim;
    public UnityEngine.AI.NavMeshAgent nma;
    public PersonGoals goals;

    public PersonWaypoints currentWaypoint;
    public PersonWaypoints previousWaypoint;
    public int waypointsVisited;

    public void Start()
    {
        anim = GetComponentInChildren<Animator>();
        nma = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        OnActionRunning();
    }

    public virtual List<System.Type> GetGoals()
    {
        return null;
    }

    public virtual float Cost()
    {
        return 0f;
    }

    public virtual void OnActionCompleted()
    {

    }
    public virtual void OnActionActivated()
    {

    }
    public virtual void OnActionDeactivate()
    {
        
    }

    public void SetDestination()
    {
        if (waypointsVisited > 0)
        {
            PersonWaypoints nextWaypoint = currentWaypoint.NextWaypoint(previousWaypoint);
            previousWaypoint = currentWaypoint;
            currentWaypoint = nextWaypoint;
        }

        Vector3 targetVector = currentWaypoint.transform.position;
        nma.SetDestination(targetVector);
    }

    

}

