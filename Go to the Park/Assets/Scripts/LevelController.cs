using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // private PlayerController pc;
    // private Level level1;
    // private Level level2;
    // private Level level3;

    // private Level[] levels;
    // private Level currentLevel;
    // public int currentLevelIndex = 1;
    // private string scene;

  

    // public void levelNext()
    // {
    //     if (currentLevelIndex <= 2)
    //     {
    //         currentLevelIndex += 1;
    //         changeLevel();
    //     } 
    // }

    // public void levelPrev()
    // {
    //     if (currentLevelIndex >= 2)
    //     {
    //         currentLevelIndex -= 1;
    //         changeLevel(); 
    //     }
    // }

    // private void changeLevel()
    // {
    //     SceneManager.LoadScene("Level" + currentLevelIndex + "Selector");
    // }

    // void Start()
    // {
    //     level1 = ScriptableObject.CreateInstance<Level>();
    //     level1.tag = "Level1";

    //     level2 = ScriptableObject.CreateInstance<Level>();
    //     level2.tag = "Level2";

    //     level3 = ScriptableObject.CreateInstance<Level>();
    //     level3.tag = "Level3";

    //     levels = new Level[] {level1, level2, level3};
    // }

    // void Update()
    // {
    //     scene = SceneManager.GetActiveScene().name;
    //     string sceneCheck = scene;

    //     Debug.Log(scene);

    //     if (scene != sceneCheck)
    //     {
    //         ChangeLevel();
    //     }
    // }

    // private void ChangeLevel()
    // {
    //     if (scene == "Level1Selector")
    //     {
    //         currentLevel = level1;
    //     }
    //     if (scene == "Level2Selector")
    //     {
    //         currentLevel = level2;
    //     }
    //     if (scene == "Level3Selector")
    //     {
    //         currentLevel = level3;
    //     }

    //     currentLevel.InitializeStars();

    //     if (currentLevel.allowedToProceed)
    //     {
    //         currentLevel.UnlockLevel();
    //     }
    // }



    



    // private void showCurrentLevelItems()
    // {

    //     List<GameObject> currentObjects = GameObject.FindGameObjectsWithTag(currentLevel.tag).ToList();

    //     Debug.Log("Current" + currentLevel.tag);

    //     foreach (GameObject o in currentObjects)
    //     {
    //         o.SetActive(true);
    //     }
    // }

    // private void hideNonCurrentLevelItems()
    // {
    //     List<Level> notCurrentLevels = levels.OfType<Level>().ToList(); 

    //     notCurrentLevels.Remove(currentLevel);

    //     Level[] notCurrentL = notCurrentLevels.ToArray();

    //     foreach (Level l in notCurrentL)
    //     {
    //         List<GameObject> levelObjects = GameObject.FindGameObjectsWithTag(l.tag).ToList();

    //         Debug.Log("Hidden" + l.tag);

    //         foreach (GameObject o in levelObjects)
    //         {
    //             Debug.Log(o.name);
    //             o.SetActive(false);
    //         }
    //     }
    // }
}
