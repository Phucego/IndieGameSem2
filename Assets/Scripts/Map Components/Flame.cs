using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Flame : MonoBehaviour
{
    
    public GameObject player;
    [SerializeField] private GameObject respawnPoint;
    [SerializeField] private Animator transition;
    private float transitionTime = 1.4f;

    private Scene scene;
    private void Start()
    {
        player = GameObject.Find("Player");
        respawnPoint = GameObject.Find("RespawnPoint");
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(RemovePlayerWhileTrans());
        }   
    }
    //Prevent the player to continue while the transition is running
    IEnumerator RemovePlayerWhileTrans()
    {
        transition.SetTrigger("isDead");
        player.SetActive(false);
        player.transform.position = respawnPoint.transform.position;
        
        yield return new WaitForSeconds(transitionTime / 2);
        player.SetActive(true);
    }
}
