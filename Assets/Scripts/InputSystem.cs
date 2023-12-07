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
    public float jumpPower, moveSpeed, horizontal, jumpTime, groundCheckRadius;
    public bool  isJumping, isFacingRight, isInteractButtonPressed;
    public LayerMask platformLayer;
    public Transform groundChecking;
    private bool isGrounded;
    private float jumpTimeCounter;
    Vector2 playerMovementDir = Vector2.zero, movementInput;

    ButtonScript jump;
    //Input actions
    public InputAction playerControls;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
    private void Awake()
    {
        
    }
    //Handle Jump inputs
    public void Jump(InputAction.CallbackContext ctx)
    {
      
        isGrounded = Physics2D.OverlapCircle(groundChecking.position, groundCheckRadius, platformLayer);
        if (isGrounded == true /*&& Input.GetKeyDown(KeyCode.Space)*/)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2d.velocity = Vector2.up * jumpPower;
            //rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Debug.Log(Vector2.up * jumpPower);
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
        Time.timeScale = 0f;
        SceneManager.LoadScene("PauseScene");
    }


    //If the player is at the ground
    
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
    //PLAYER'S MOVEMENTS

    public void Movement()
    {
        Vector2 playerVelocity = new Vector2(playerMovementDir.x * moveSpeed, rb2d.velocity.y);   
        rb2d.velocity = playerVelocity;
        
        FlippingDirections();
        
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
