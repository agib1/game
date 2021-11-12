using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

//Class used to select levels using an instances of the Level class - not currently in use.
public class LevelSelector : MonoBehaviour
{
    private Level level1;
    private Level level2;
    private Level level3;

    private Level[] levels;

    private Level currentLevel;
    private int currentLevelIndex;
    private int[] notCurrentIndexs;

    private List<GameObject> level1Objects;
    private List<GameObject> level2Objects;
    private List<GameObject> level3Objects;

    private List<GameObject>[] levelObjects;

    void Start()
    {
        InitializeLevels();
        InitializeUI();
    }

    private void InitializeLevels()
    {
        level1 = ScriptableObject.CreateInstance<Level>();
        level1.tag = "Level1";

        level2 = ScriptableObject.CreateInstance<Level>();
        level2.tag = "Level2";

        level3 = ScriptableObject.CreateInstance<Level>();
        level3.tag = "Level3";

        levels = new Level[] {level1, level2, level3};

        currentLevelIndex = 0;
        notCurrentIndexs = getNotCurrentIndexs();
        
        currentLevel = level1;
        // currentLevel = levels[currentLevelIndex];
    }

    private void InitializeUI()
    {
        level1Objects = GameObject.FindGameObjectsWithTag(level1.tag).ToList();
        level2Objects = GameObject.FindGameObjectsWithTag(level2.tag).ToList();
        level3Objects = GameObject.FindGameObjectsWithTag(level3.tag).ToList();

        Debug.Log(level1Objects.Count);

        levelObjects = new List<GameObject>[] {level1Objects, level2Objects, level3Objects};

        hideNotCurrentObjects();
    }
    public void NextLevel()
    {
        if (currentLevelIndex <= 2)
        {
            currentLevelIndex += 1;
            //currentLevel = levels[currentLevelIndex];
            notCurrentIndexs = getNotCurrentIndexs();

            hideNotCurrentObjects();
            showCurrentObjects();
        }
       
    }

    public void PreviousLevel()
    {
        if (currentLevelIndex >= 2)
        {
            currentLevelIndex -= 1;
            //currentLevel = levels[currentLevelIndex];
            notCurrentIndexs = getNotCurrentIndexs();

            hideNotCurrentObjects();
            showCurrentObjects();
        }
    }

    public void SelectLevel()
    {
        if (currentLevel = level1)
        {
            SceneManager.LoadScene("Level 1");
        }
        // if (currentLevel = level2)
        // {
        //     SceneManager.LoadScene("Level 2");
        // }
        // if (currentLevel = level3)
        // {
        //     SceneManager.LoadScene("Level 3");
        // }
    }

    

    private void hideNotCurrentObjects()
    {
        List<GameObject> notCurrentObjects = levelObjects[notCurrentIndexs[0]].Concat(levelObjects[notCurrentIndexs[0]]).ToList();

        foreach (GameObject o in notCurrentObjects)
        {
            o.SetActive(false);
        }
    }

    private void showCurrentObjects()
    {
        List<GameObject> currentObjects = levelObjects[currentLevelIndex];

        foreach (GameObject o in currentObjects)
        {
            o.SetActive(true);
        }
    }

    private int[] getNotCurrentIndexs()
    {
        int[] indexs = new int[] {1, 2, 3};

        return indexs.Where(val => val != currentLevelIndex).ToArray();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
