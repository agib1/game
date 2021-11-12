using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    public void SelectRoute() 
    {
        SceneManager.LoadScene("Level Selector");
    }

    public void MainQuit()
    {
        Application.Quit();
    }
}
