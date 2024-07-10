using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenuManager : MonoBehaviour
{
    public GameObject resumeButton, backToMainMenuButton, pausePanel;

    public void BackToMainMenu()
    {
        AudioManager.Instance.PlaySoundEffect("ClickSound_SFX");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        AudioManager.Instance.PlaySoundEffect("ClickSound_SFX");
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void ResetLevel()
    {
        AudioManager.Instance.PlaySoundEffect("ClickSound_SFX");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
