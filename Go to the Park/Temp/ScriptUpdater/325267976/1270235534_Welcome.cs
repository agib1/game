using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Welcome screen to start game from - games initial state
public class Welcome : MonoBehaviour
{
    public void SelectRoute() 
    {
        FindObjectOfType<AudioManager>().Play("Background");
        GetComponent<AudioSource>().Play("Background");
        SceneManager.LoadScene("Level Selector");
    }

    public void MainQuit()
    {
        Application.Quit();
    }
}
