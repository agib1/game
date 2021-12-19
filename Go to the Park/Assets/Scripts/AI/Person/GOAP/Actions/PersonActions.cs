using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//base class for person goap actions
public interface Actions
{
    List<System.Type> GetGoals();
    float Cost();
    void OnActionRunning();
    void OnActionActivated();
    void OnActionDeactivated();

}

public class PersonActions : MonoBehaviour, Actions
{
    public Animator anim;
    public NavMeshAgent nma;
    public PersonGoals goals;

    public PersonWaypoints currentWaypoint;
    public PersonWaypoints previousWaypoint;
    public int waypointsVisited;

    public void Start()
    {
        anim = GetComponentInChildren<Animator>();
        nma = this.GetComponent<NavMeshAgent>();
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

    public virtual void OnActionRunning()
    {

    }
    public virtual void OnActionActivated()
    {

    }
    public virtual void OnActionDeactivated()
    {

    }

    // pathfinding, set destination of next node to move to.
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

