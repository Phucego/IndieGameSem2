using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextManager : MonoBehaviour
{

    public static TutorialTextManager instance;

    public GameObject tutText;
    private void Awake()
    {
        //If there is an instance and it is not the player, then delete
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        tutText.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tutText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tutText.SetActive(false);
        }
    }
}

