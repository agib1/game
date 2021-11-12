using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Text willToKeepGoingText;

    
    //Postive Feedback Loop: Player can choose to go around collecting poweups.
    //This will increase their time, making it less likely they will have enough stars (time completion based) to proceed to the next level.
    //However, the points gained with the powerups can reduce likleyness to die by loosing energy from getting hit by AI Cars and Humans.
    //The player can also choose to not collect powerups and instead save time, but increses the probability of failure.
    private void OnTriggerEnter(Collider other)
    {
        //Stochastic behavior: Only half of the "Food" Podiums actually have the powerup.
        //However, this is not viewable from the player perspective, so is completely random.
        if (other.gameObject.CompareTag("Food"))
        {
            willToKeepGoing += foodPoints;
        }

        if (other.gameObject.CompareTag("Drink"))
        {
            willToKeepGoing += drinkPoints;
        }
    }

    //Collision Detection with dynamic changes over time: When the player collides with the AI elements,
    //they loose energy, making it more likely for them to fail the level.
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

    //Collision Detection - Physics: When the player collides with the AI elements, physics is used as a responce.
    void PhysicsCollisonResponse(int mass)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        willToKeepGoing = 100;

        willToKeepGoingText = GameObject.Find("WillToKeepGoingText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        willToKeepGoingText.text = "Will To Keep Going: " + willToKeepGoing;
    }
}
