using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

//Menu class with game options and progression screens
public class Menu : MonoBehaviour
{
    private string currentLevel;

    private GameObject[] gameObjects;
    private GameObject[] menuObjects;
    private GameObject[] failObjects;
    private GameObject[] finishObjects;
    private GameObject[] menuCopy;

    public void Pause() 
    {
        currentLevel = SceneManager.GetActiveScene().name;

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

    public void Fail()
    {
        foreach (GameObject o in gameObjects)
        {
            o.SetActive(false);
        }

        foreach (GameObject o in failObjects)
        {
            o.SetActive(true);
        }
    }

    public void Finish()
    {
        foreach (GameObject o in gameObjects)
        {
            o.SetActive(false);
        }

        foreach (GameObject o in finishObjects)
        {
            o.SetActive(true);
        }
    }

    public void Next()
    {
        string nextLevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nextLevel);
    }

    private void Start()
    {
        menuObjects = GameObject.FindGameObjectsWithTag("MenuCanvas");
        failObjects = GameObject.FindGameObjectsWithTag("FailCanvas");
        finishObjects = GameObject.FindGameObjectsWithTag("FinishCanvas");
        gameObjects = GameObject.FindGameObjectsWithTag("GameCanvas");
        
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
