using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayerManager : MonoBehaviour
{

    
    public float transitionTime = 1.6f;

    public static KillPlayerManager Instance;
    private Scene scene;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    //Prevent the player to continue while the transition is running
    public void Respawn()
    {
        //TODO: Respawn the player to the nearest checkpoint
        PlayerController.instance.RespawnToCheckpoint();
        AudioManager.Instance.PlaySoundEffect("Hurt_SFX");
   
    }
}
