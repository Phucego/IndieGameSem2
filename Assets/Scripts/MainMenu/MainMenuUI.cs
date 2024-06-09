using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public MainMenuUI Instance;
    public bool isStartingGame;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        isStartingGame = true;
        StartCoroutine(StartingGameDelay());


    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator StartingGameDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(1);
        
    }
}
