using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//AI Flocking: if person collision with player, add person to angry flock, creating barricade, harder to complete level.
public class PersonFlocking : MonoBehaviour
{
    public List<GameObject> flockingList; 

    public Transform flockTransform {get; set;}

    float smoothDamp;

    Vector3 velocity;
    float speed = 3f;

    void Start()
    {
        flockingList = new List<GameObject>();
        velocity = new Vector3(1f, 0f, 1f);
    }

    void Update()
    {
        MoveFlock();
    }

    public void AddToFlock(GameObject angryHuman)
    {
        flockingList.Add(angryHuman);
    }

    public void MoveFlock()
    {
        var cohesion = CalculateCohesion();
        var move = Vector3.SmoothDamp(flockTransform.forward, cohesion, ref velocity, smoothDamp);
        move = move.normalized * speed;
        flockTransform.forward = move;
        flockTransform.position += move * Time.deltaTime;
    }

    Vector3 CalculateCohesion()
    {
        var cohesion = Vector3.zero;

        foreach (GameObject person in flockingList)
        {
            cohesion += person.transform.position;
        }

        cohesion /= flockingList.Count;

        return cohesion;
    }
}