using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level : ScriptableObject
{
    public string tag;
    public bool completed = false;
    public bool locked = true;
    public int stars = 0;
    public bool allowedToProceed = false;
    private List<GameObject> levelObjects;
    private GameObject star1;
    private GameObject star2;
    private GameObject star3;

    public void InitializeStars()
    {
        levelObjects = GameObject.FindGameObjectsWithTag(tag).ToList();

        Debug.Log(tag);

        star1 = levelObjects.Find(obj=>obj.name=="star1");
        star2 = levelObjects.Find(obj=>obj.name=="star2");
        star3 = levelObjects.Find(obj=>obj.name=="star3");
        
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        if (tag == "Level1")
        {
            allowedToProceed = true;
        }
    }
    
    public void UnlockLevel()
    {
        if (allowedToProceed == true)
        {
            locked = false;

            GameObject lockIcon = levelObjects.Find(obj=>obj.name=="Lock");

            lockIcon.SetActive(false);
        }
     
    }

    public void SetAsCompleted(float time)
    {
        if (time <= 3) 
        {
            stars = 1;
            star1.SetActive(true);
        }
        if (time <= 2)
        {
            stars = 2;
            star2.SetActive(true);
        }
        if (time <= 1)
        {
            stars = 3;
            star2.SetActive(true);
        }

        completed = true;   

        if (stars >= 2)
        {
            allowedToProceed = true;
        }
    }
}
