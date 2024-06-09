using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition_MainMenu : MonoBehaviour
{
    private Animator anim;
    private MainMenuUI _mainMenuUI;
    [SerializeField] private GameObject canvasButtons;
    private void Start()
    {
        anim = GetComponent<Animator>();
        _mainMenuUI = FindObjectOfType<MainMenuUI>();
    }

    private void Update()
    {
        if (_mainMenuUI.Instance.isStartingGame)
        {
            anim.SetTrigger("startTrans");
            canvasButtons.SetActive(false);
        }
        else
        {
            canvasButtons.SetActive(true);
        }
    }
}
