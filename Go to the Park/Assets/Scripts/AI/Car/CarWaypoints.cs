using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI for car pathfinding
public class CarWaypoints : MonoBehaviour
{
    [SerializeField]
    protected float debugFieldRad = 1f;

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, debugFieldRad);
    }

}