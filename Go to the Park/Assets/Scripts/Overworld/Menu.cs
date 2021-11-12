using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Menu class with game options and progression screens
public class Menu : MonoBehaviour
{
    private string currentLevel;

    private GameObject[] gameObjects;
    private GameObject[] menuObjects;
    private GameObject[] failObjects;
    private GameObject[] finishObjects;

    public void Pause() 
    {
        currentLevel = SceneManager.GetActiveScene().name;

        gameObjects = GameObject.FindGameObjectsWithTag("GameCanvas");
        
        foreach (GameObject o in gameObjects)
        {
            o.SetActive(false);
        }

        foreach (GameObject o in menuObjects)
        {
            o.SetActive(true);
        }
    }

    public void Resume()
    {
        foreach (GameObject o in menuObjects)
        {
            o.SetActive(false);
        }

        foreach (GameObject o in gameObjects)
        {
            o.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Welcome");
    }

    private void Start()
    {
        menuObjects = GameObject.FindGameObjectsWithTag("MenuCanvas");
        failObjects = GameObject.FindGameObjectsWithTag("FailCanvas");
        finishObjects = GameObject.FindGameObjectsWithTag("FinishCanvas");
        
        foreach (GameObject o in menuObjects)
        {
            o.SetActive(false);
        }

        foreach (GameObject o in failObjects)
        {
            o.SetActive(false);
        }

        foreach (GameObject o in finishObjects)
        {
            o.SetActive(false);
        }
    }
}
