using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Cloud : MonoBehaviour
{
    public float dissolveTimer = 1.5f;
    public float respawnCloudTimer;
    private float shakePower, vibrateCount;
    public int vibration, randomness;

    public SpriteRenderer _sr;
    public BoxCollider2D _boxCollider2D;
    [SerializeField] private GameObject cloudobj;
    public Vector2 shakeStrength;
    public bool isCloudDestroyed;

    private void Start()
    {
        DOTween.Init();
        cloudobj = GetComponent<GameObject>();
        _sr = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartTimer());
            var direction = transform.position - other.transform.position;
            direction.y = 0;
            transform.DOComplete();
            gameObject.transform.DOShakePosition(dissolveTimer, shakeStrength.normalized, vibration, randomness);
            StartCoroutine(RespawnCloud());
        }
    }
    
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(dissolveTimer);
        _sr.enabled = false;
        _boxCollider2D.enabled = false; 
    }
    IEnumerator RespawnCloud()
    {
        yield return new WaitForSeconds(respawnCloudTimer);
        gameObject.SetActive(true);
        _sr.enabled = true;
        _boxCollider2D.enabled = true;
    }
}
