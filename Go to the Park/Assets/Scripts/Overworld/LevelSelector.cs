using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

//Class used to select levels using an instances of the Level class
public class LevelSelector : MonoBehaviour
{
    string[] levels;

    int no_levels = 2;
    List<GameObject>[] levelObjects;

    string currentLevel;

    int currentLevelIndex;
    void Start()
    {
        InitializeLevels();
        InitializeUI();
    }

    private void InitializeLevels()
    {
        levels = new string[] {"level1", "level2"};

        currentLevelIndex = 0;
        
        currentLevel = levels[currentLevelIndex];
    }

    private void InitializeUI()
    {
        List<GameObject> level1Objects = GameObject.FindGameObjectsWithTag("Level1").ToList();
        List<GameObject> level2Objects = GameObject.FindGameObjectsWithTag("Level2").ToList();

        levelObjects = new List<GameObject>[] {level1Objects, level2Objects};

        hideObjects();
        showCurrentObjects();
    }
    public void NextLevel()
    {
        if (currentLevelIndex < no_levels)
        {
            currentLevelIndex += 1;
 

            hideObjects();
            showCurrentObjects();
        }
       
    }

    public void PreviousLevel()
    {
        if (currentLevelIndex > 0)
        {
            currentLevelIndex -= 1;

            hideObjects();
            showCurrentObjects();
        }
    }

    public void SelectLevel()
    {
        if (currentLevel == "level1")
        {
            SceneManager.LoadScene("Level 1");
        }
        // if (currentLevel = level2)
        // {
        //     SceneManager.LoadScene("Level 2");
        // }
    }

    private void showCurrentObjects()
    {
        List<GameObject> currentObjects = levelObjects[currentLevelIndex];

        foreach (GameObject o in currentObjects)
        {
            o.SetActive(true);
        }
    }

    private void hideObjects()
    {
        foreach (List<GameObject> os in levelObjects)
        {
            foreach (GameObject o in os)
            {
                o.SetActive(false);
            }
            
        }
    }
}
