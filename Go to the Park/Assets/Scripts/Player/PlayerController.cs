using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


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

    public bool levelCompleted;

    private Text willToKeepGoingText;

    private Text timeText;

    private Text finishText;

    private bool timerGoing;

    private float startTime;

    private float timeElapsed;

    public Menu menu;

    public Level level;


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
            timerGoing = false;

            int time_range = ((int) timeElapsed /60);
            menu.Finish();
            level.SetAsCompleted(time_range);
        }

    }

    void Start()
    {
        willToKeepGoing = 100;

        willToKeepGoingText = GameObject.Find("WillToKeepGoingText").GetComponent<Text>();

        timeText = GameObject.Find("TimerText").GetComponent<Text>();

        finishText = GameObject.Find("FinishTime").GetComponent<Text>();

        timerGoing = true;
        startTime = Time.time;

        menu = GetComponent<Menu>();
        level = GetComponent<Level>();
        
    }

    void Update()
    {
        willToKeepGoingText.text = "Will To Keep Going: " + willToKeepGoing;

        if (willToKeepGoing <= 0) {
            menu.Fail();
        }

        StartCoroutine(Timer());
      
    }


    //Gameplay progression: timer records how long player takes to complete level to decide if fast enough to proceed to next.
    IEnumerator Timer() {
        while(timerGoing)
        {
            timeElapsed = Time.time - startTime;
            string mins = ((int) timeElapsed /60).ToString();
            string secs = (timeElapsed % 60).ToString("f0");
            timeText.text = "Time Taken: " + mins + " : " + secs;
            finishText.text = "You finished in: " + mins + " : " + secs;
            yield return null;
        }
    }
}
