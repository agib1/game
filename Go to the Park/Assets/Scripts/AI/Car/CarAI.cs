using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

//Pathfinding and AI to move car
//Paths are set manually due to nature of car.
public class CarAI : MonoBehaviour
{
    public float waitTime = 0f;

    public bool pointWaiting;

    public float switchProbability = 0f;

    public List<CarWaypoints> carPoints;

    Transform destination;
    NavMeshAgent nma;
    int currentPointIndex;
    bool travelling;
    bool waiting;
    bool pointFoward;
    float waitTimer;

    private void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        currentPointIndex = 0;
        SetDestination();
    }

    private void Update()
    {
        if (travelling && nma.remainingDistance <= 1f)
        {
            travelling = false;

            if (pointWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePoint();
                SetDestination();
            }

        }

        if (waiting)
        {
            waitTimer = Time.deltaTime;

            if (waitTimer > waitTime)
            {
                waiting = false;

                ChangePoint();
                SetDestination();
            }
        }
    }
    
    private void SetDestination()
    {
        Vector3 targetVector = carPoints[currentPointIndex].transform.position;
        nma.SetDestination(targetVector);
        travelling = true;

    }

    private void ChangePoint()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= switchProbability)
        {
            pointFoward = !pointFoward;
        }

        if (pointFoward)
        {
            currentPointIndex = (currentPointIndex + 1) % carPoints.Count;
        }
        else
        {
            if (--currentPointIndex < 0)
            {
                currentPointIndex = carPoints.Count - 1;
            }
        }
    }

}