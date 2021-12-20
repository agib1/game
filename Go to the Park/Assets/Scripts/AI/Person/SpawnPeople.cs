using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Design Patterns: Prototype: Cloning.
//Spawns n people and pathfinding points relative to size of game track
public class SpawnPeople : MonoBehaviour
{

    public GameObject person;
    public GameObject personWaypoint;

    public Transform personParent;
    public Transform pointParent;

    private int noOfPeople;
    private int noOfPoints;

    private float trackX;
    private float trackZ;

    public void Start()
    {
        GameObject track = GameObject.Find("Track");
        Vector3 tracksize = track.transform.localScale;

        trackX  = (tracksize.x / 2);
        trackZ = (tracksize.z / 3);

        noOfPeople = (int)((tracksize.x * tracksize.z) / 100);
        noOfPoints = noOfPeople;

        for (int i = 0; i < noOfPeople; i++)
        {
            Vector3 position = new Vector3(Random.Range(-trackX, trackX),0f,Random.Range(-trackZ*2, trackZ));
            Instantiate(person, position, Quaternion.identity, personParent);  
        }

        for (int i = 0; i < noOfPoints; i++)
        {
            Vector3 position = new Vector3(Random.Range(-25f, 25f),0f,Random.Range(-trackZ*2, trackZ));
            Instantiate(personWaypoint, position, Quaternion.identity, pointParent);
        }
    }
}