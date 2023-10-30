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
        rb2d.velocity = new Vector2(horizontal * moveSpeed, rb2d.velocity.y);

        FlippingDirections();
    }
    private void FixedUpdate()
    {


    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && IsGrounded())
        {  
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
            Debug.LogWarning(ctx.control.name);

        }
        
    }

    public void LeftMovement(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            
        }
    }





    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundChecking.position, .2f, platformLayer);
    }
    void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    void FlippingDirections()
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
