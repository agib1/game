using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Welcome screen to start game from - games initial state
public class Welcome : MonoBehaviour
{

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Background");
    }
    public void SelectRoute() 
    {
        SceneManager.LoadScene("Level Selector");
    }

    public void MainQuit()
    {
        Application.Quit();
    }
}
