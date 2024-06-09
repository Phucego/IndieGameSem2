using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int damageAmt = 1;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<HealthManager>() != null)
        {
            collision.transform.GetComponent<HealthManager>().DealDamage(damageAmt);
        }
    }
}