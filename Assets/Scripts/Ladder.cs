using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical, speed = 8f;
    private bool isLadder, isClimbing;

    [SerializeField]
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
        
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb2d.gravityScale = 0f;
            rb2d.velocity = new Vector2(rb2d.velocity.x, vertical * speed);
        }
        if(!isClimbing)
        {
            rb2d.gravityScale = 4f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isLadder = false;
        isClimbing = true;
    }
}
