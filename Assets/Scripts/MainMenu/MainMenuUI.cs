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
        AudioManager.Instance.PlaySoundEffect("ClickSound_SFX");
        isStartingGame = true;
        StartCoroutine(StartingGameDelay());

    }

    public void Quit()
    {
        AudioManager.Instance.PlaySoundEffect("ClickSound_SFX");
        Application.Quit();
    }

    IEnumerator StartingGameDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(1);
        
    }
}
