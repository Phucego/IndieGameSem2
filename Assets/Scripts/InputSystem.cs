using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputSystem : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float jumpPower, moveSpeed, horizontal;
    public bool  isJumping, isFacingRight;
    public LayerMask platformLayer;
    public Transform groundChecking;
 


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FlippingDirections();
    }
    private void FixedUpdate()
    {


    }
    //Handle Jump inputs
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && IsGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
            
        }
    }

    public void Movement(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            rb2d.velocity = ctx.ReadValue<Vector2>() * moveSpeed;
        }
        
    }

    //If the player is at the ground
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecking.position, .2f, platformLayer);    //create a circle taking the ground check GameObject's position
    }
    void FlipCharacter()    //flipping character function
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    void FlippingDirections()   //function deciding whether the character will flip or not
    {
        if (!isFacingRight && horizontal > 0f)
        {
            FlipCharacter();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            FlipCharacter();
        }
    }
}
