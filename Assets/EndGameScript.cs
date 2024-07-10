using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(EndTheGame());
    }

    IEnumerator EndTheGame()
    {

        yield return new WaitForSeconds(9.33f);
        SceneManager.LoadScene(0);

    }
}
