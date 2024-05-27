using System;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firePoint, endPoint;
    public float fireRate = 2f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireArrow();
            nextFireTime = Time.time + 1f / fireRate;
        }

        
    }

    void FireArrow()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        
    }

  
}