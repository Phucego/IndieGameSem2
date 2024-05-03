using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class InputSystem : MonoBehaviour
{
    //Player related
    Animator anim;
    Rigidbody2D rb2d;
    
    public bool isGrounded;
    public bool  isJumping, isFacingRight, isInteractButtonPressed;

    public LayerMask platformLayer;

    public Transform groundChecking;
    [SerializeField] private Transform grabDetectPos, boxHoldingPos;
    
    private float jumpTimeCounter;
    public float jumpPower, moveSpeed, horizontal, jumpTime, groundCheckRadius;
    
    Vector2 playerMovementDir = Vector2.zero;
    ButtonScript jump;
    //Input actions
    public InputAction playerControls;
    // Start is called before the first frame update
    
    SpriteRenderer sr;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Reading values
        playerMovementDir = playerControls.ReadValue<Vector2>();
        
    }
    private void FixedUpdate()      //handle physics
    {
        Movement();
    }
    //Handle Jump inputs
    public void Jump(InputAction.CallbackContext ctx)
    {
        isGrounded = Physics2D.OverlapCircle(groundChecking.transform.position, groundCheckRadius, platformLayer);
        if (isGrounded == true /*&& Input.GetKeyDown(KeyCode.Space)*/)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2d.velocity = Vector2.up * jumpPower;
            //rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * jumpPower;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            rb2d.velocity = Vector2.up * jumpPower;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    
    public void CounterJump(InputAction.CallbackContext ctx)
    {
        rb2d.AddForce(-transform.up * jumpPower, ForceMode2D.Impulse);
    }
    public void PauseGame(InputAction.CallbackContext ctx)
    {
        
    }
    
    //PLAYER'S MOVEMENTS

    public void Movement()
    {
        sr.flipX = isFacingRight;
        
        Vector2 playerVelocity = new Vector2(playerMovementDir.x * moveSpeed, rb2d.velocity.y);   
        rb2d.velocity = playerVelocity;

        //Flip the player sprite
        if (playerVelocity.x > 0)
        {
            isFacingRight = true;
            
        }
        else if(playerVelocity.x < 0)
        {
            isFacingRight = false;
            //this.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (playerVelocity.x > 0 || playerVelocity.x < 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        
    }


    void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
}
