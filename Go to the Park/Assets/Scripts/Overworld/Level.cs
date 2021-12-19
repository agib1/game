using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

//Level class that records the status of a given level. Used for game play progression.
//Level is unlocked if previous level has recieved over two stars.
public class Level : MonoBehaviour
{
    public bool completed = false;
    public bool locked = true;
    public int stars = 0;
    public bool allowedToProceed = false;
    private GameObject star1;
    private GameObject star2;
    private GameObject star3;

    //gameplay progression: level needs to be unlocked before allowed to play
    public void UnlockLevel()
    {
        if (allowedToProceed == true)
        {
            locked = false;
        }
     
    }

    public void SetAsCompleted(float time)
    {
        //gameplay progression: uses time completed to determain star level and decide if allowed to proceed to next level
        star1 = GameObject.Find("fstar1");
        star2 = GameObject.Find("fstar2");
        star3 = GameObject.Find("fstar3");
        
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        GameObject fail = GameObject.Find("Fail");
        fail.SetActive(false);
        
        GameObject contin = GameObject.Find("NextLev");
        contin.SetActive(false);

        if (time == 2) 
        {
            stars = 1;
            star1.SetActive(true);
        }
        if (time == 1)
        {
            stars = 2;
            star2.SetActive(true);
        }
        if (time == 0)
        {
            stars = 3;
            star3.SetActive(true);
        }

        completed = true;   

        //gameplay progression: only allowed to proceed if acheived more than 2 stars
        if (stars >= 2)
        {
            allowedToProceed = true;
            contin.SetActive(true);
        }

        if (stars < 2)
        {
            fail.SetActive(true);
        }
    }
}
