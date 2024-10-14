using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static PlayerController playerController;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Game Manager is Null");
            }

            return instance;
        }
    }

    //Variables
    public int points;
    public int winPoints;
    public int sceneToLoad;

    private void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (points >= winPoints)
        {
            LoadScene(sceneToLoad);
        }
    }

    public void PointsUp(int gain)
    {
        points += gain;
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

