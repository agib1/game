using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int foodPoints = 20;
    [SerializeField]
    private int drinkPoints = 10;
    [SerializeField]
    private int humanPoints = 5;
    [SerializeField]
    private int carPoints = 30;
    [SerializeField]
    private int willToKeepGoing = 100;
    public float timeTaken;

    public bool levelCompleted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            willToKeepGoing += foodPoints;
        }

        if (other.gameObject.CompareTag("Drink"))
        {
            willToKeepGoing += drinkPoints;
        }

        if (other.gameObject.CompareTag("Car"))
        {
            willToKeepGoing -= carPoints;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            willToKeepGoing -= humanPoints;

        }

        if (collision.gameObject.CompareTag("Car"))
        {
            willToKeepGoing -= carPoints;
        }

        if (collision.gameObject.CompareTag("Nature"))
        {
            levelCompleted = true;
            //stop timer, get time
            //pass to LevelSelector
        }
    }

    void PhysicsCollisonResponse(int mass)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        willToKeepGoing = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
