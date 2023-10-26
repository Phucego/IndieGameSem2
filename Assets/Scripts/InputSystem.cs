using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputSystem : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float jumpPower;

    public GameObject groundCheck;

    public bool canJump;
    public bool isJumping;

    public LayerMask platform;

    BoxCollider2D boxcol2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        canJump = true;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
   
        
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && canJump == true && isJumping == false)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
            canJump = false;
        }
        else
        {
            isJumping = false;
            canJump = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
            canJump = true;
        }
    }
}
