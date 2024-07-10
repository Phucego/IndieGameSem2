using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkPointText;


    private void Start()
    {
        
        checkPointText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO: Update respawn position, appear text and disable the checkpoint box col
        if (other.CompareTag("Player"))
        {
            //TODO: Update the player's position to the checkpoint position
            PlayerController.instance.UpdatePointPos(transform.position);
            StartCoroutine(EnableText());
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    IEnumerator EnableText()
    {
        checkPointText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        checkPointText.SetActive(false);
      
    }
}
