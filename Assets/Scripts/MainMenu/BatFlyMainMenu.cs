using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BatFlyMainMenu : MonoBehaviour
{
    public GameObject startPoint;

    public GameObject endPoint;

    private Rigidbody2D rb2d;
    private float _speed = 0.2f;
    
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        startPoint = GameObject.Find("BatSpawn");
        
        endPoint = GameObject.Find("BatKill");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        var randomSpeed = Random.Range(0.1f, 1f);
        rb2d.velocity = new Vector2(endPoint.transform.position.x * randomSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("KillBat"))
        {
            Destroy(gameObject);
        }
    }
}
