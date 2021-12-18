using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonWaypoints : MonoBehaviour
{
    //Pathfinding
    [SerializeField]
    //UI for node
    protected float debugFieldRad = 1f;

    [SerializeField]
    //UI for Edges
    protected float connectivityRad = 200f;

    //List of nodes
    List<PersonWaypoints> connections;

    public void Start()
    {
        GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        connections = new List<PersonWaypoints>();

        for(int i = 0; i < allWaypoints.Length; i++)
        {
            PersonWaypoints nextWaypoint = allWaypoints[i].GetComponent<PersonWaypoints>();

            if(nextWaypoint != null)
            {
                if (Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= connectivityRad && nextWaypoint != this)
                {
                    connections.Add(nextWaypoint);
                }
            }
        }
    }

    //UI for nodes and edges
    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugFieldRad);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, connectivityRad);
    }

    //A* Pathfinfing to find the next node 
    public PersonWaypoints NextWaypoint(PersonWaypoints previousWayPoint)
    {
        if(connections.Count == 0)
        {
            return null;
        }
        else if(connections.Count == 1 && connections.Contains(previousWayPoint))
        {
            return previousWayPoint;
        }
        else 
        {
            PersonWaypoints nextWaypoint;
            int nextIndex = 0;

            do
            {
                nextIndex = UnityEngine.Random.Range(0, connections.Count);
                nextWaypoint = connections[nextIndex];

            } while (nextWaypoint == previousWayPoint);

            return nextWaypoint;
        }
    }


}