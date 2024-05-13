using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CloudManager : MonoBehaviour
{
    public float dissolveTimer = 1.5f;
    public float respawnCloudTimer = 4f;
    private float shakePower, vibrateCount;

    public int vibration, randomness;
    
    public Vector2 shakeStrength;

    [SerializeField] private GameObject cloudobj;
    [SerializeField] private bool isInteracted;
    public bool isCloudDestroyed;

    BoxCollider2D _boxCol2d;

    private void Start()
    {
        DOTween.Init();
        _boxCol2d = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!isInteracted)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //When the player steps on the cloud, the cloud vibrates and dissolve in 1.5sec
                StartCoroutine(StartTimer());
                isInteracted = true;
                var direction = transform.position - other.transform.position;
                direction.y = 0;
                transform.DOComplete();
                gameObject.transform.DOShakePosition(dissolveTimer, shakeStrength.normalized, vibration, randomness);
                Invoke(nameof(RespawnCloud), respawnCloudTimer);    //Invoke the respawing function
            }
        }
    }
    //Start the timer when the cloud is destroyed
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(dissolveTimer);
        cloudobj.SetActive(false);
        _boxCol2d.enabled = false;
        isCloudDestroyed = true;
    }
    //Respawning the cloud
    void RespawnCloud()
    {
        cloudobj.SetActive(true);
        isCloudDestroyed = false;
        isInteracted = false;
        _boxCol2d.enabled = true;
        
    }

}
