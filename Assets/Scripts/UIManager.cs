using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;
    private InputSystem _inputSystem;
    public GameObject[] texts;

    
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _inputSystem = GetComponent<InputSystem>();

      
    }
}
