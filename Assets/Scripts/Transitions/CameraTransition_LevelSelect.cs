using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition_LevelSelect : MonoBehaviour
{
    [SerializeField] private GameObject buttonCanvas;

    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Transitioning", true);
        StartCoroutine(SetButtonActive());
        
    }
    
    IEnumerator SetButtonActive()
    {
        buttonCanvas.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("Transitioning", false);
        buttonCanvas.SetActive(true);
    }
}
