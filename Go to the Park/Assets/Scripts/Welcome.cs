using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome : MonoBehaviour
{
    public void SelectRoute() 
    {
        SceneManager.LoadScene("Level1Selector");
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
