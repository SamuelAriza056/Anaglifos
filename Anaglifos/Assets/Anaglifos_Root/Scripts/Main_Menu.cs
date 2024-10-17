using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Lvl1");
    }

    public void PlayGame2()
    {
        SceneManager.LoadSceneAsync("lvl 1.1");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Retry()
    {
      SceneManager.LoadSceneAsync("Lvl1");
    }

    public void Retrurn()
    {
        SceneManager.LoadSceneAsync("Main_menu");
    }
}


