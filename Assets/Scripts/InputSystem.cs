using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class InputSystem : MonoBehaviour
{

    Animator anim;
    Rigidbody2D rb2d;
    public float jumpPower, moveSpeed, horizontal;
    public bool  isJumping, isFacingRight, isInteractButtonPressed;
    public LayerMask platformLayer;
    public Transform groundChecking;

    Vector2 playerMovementDir = Vector2.zero, movementInput;

    //Input actions
    public InputAction playerControls;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        horizontal = 1;
    }

    // Update is called once per frame
    void Update()
    {
    
        //Reading values
        playerMovementDir = playerControls.ReadValue<Vector2>();
        Movement();
    }
    private void FixedUpdate()      //handle physics
    {

        
    }
    private void Awake()
    {
        
    }
    //Handle Jump inputs
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (IsGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        }
    }
    
   
    public void Interaction(InputAction.CallbackContext ctx)
    {
        isInteractButtonPressed = true;
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
    //PLAYER'S MOVEMENTS

    void Movement()
    {
        Vector2 playerVelocity = new Vector2(playerMovementDir.x * moveSpeed, 0);   //prevent the player moving upwards while holding S or D
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
