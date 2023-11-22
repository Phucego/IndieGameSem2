using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f;

    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (IsFacingRight())
        {
            rb2d.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0f);
        }
    }
    bool IsFacingRight()
    {
        //Mathf.Epsilon is used check a very small value
        //For example 0.001
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb2d.velocity.x)), transform.localScale.y);
    }
}
