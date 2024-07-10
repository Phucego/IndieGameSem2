using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class ActivateTimeline : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playerableDir;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO: Disable the trigger so that the timeline does not run again.
        if(other.CompareTag("Player"))
        {
            _playerableDir.Play();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
