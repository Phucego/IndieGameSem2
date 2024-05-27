using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputSystem : MonoBehaviour
{
    //Player related
    Animator anim;
    Rigidbody2D rb2d;
    CapsuleCollider2D _capsulecol2d;

    //Booleans
    public bool isJumping, isFacingRight, isInteractButtonPressed, isGrounded, isFalling;
    [SerializeField] private bool isCrouching;


    public LayerMask platformLayer;

    public Transform groundChecking;
    [SerializeField] private Transform grabDetectPos, boxHoldingPos;

    //Floats
    private float crouchMS, originalMS;
    public float jumpPower, moveSpeed, horizontal, jumpTime, groundCheckRadius;




    Vector2 playerMovementDir = Vector2.zero;

    ButtonScript jump;

    //Input actions
    public InputAction playerControls;

    //Event Actions
    public event Action GrabItem;
    public event Action ChooseGate;


    private Collider2D groundCheckCircle;

    SpriteRenderer sr;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        _capsulecol2d = GetComponent<CapsuleCollider2D>();
        Time.timeScale = 0.95f;

        //Move speed adjustments for crouching
        crouchMS = moveSpeed - 3;
        originalMS = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Reading values
        playerMovementDir = playerControls.ReadValue<Vector2>();

        Debug.Log(isGrounded);
        //Debug.Log(isJumping);

    }

    private void FixedUpdate() //handle physics
    {
        Movement();

    }

    //Handle Jump inputs
    public void Jump(InputAction.CallbackContext ctx)
    {
        //TODO: Check if the player is on the ground, then jump
        groundCheckCircle = Physics2D.OverlapCircle(groundChecking.transform.position, groundCheckRadius, platformLayer);
        var originalCapsuleSize = _capsulecol2d.size = new Vector2(1.33f, 2.06f);
        
        //TODO: If all of these conditions are met, the player can jump
        if (!isCrouching && !isJumping && groundCheckCircle)
        {
            rb2d.velocity = Vector2.up * jumpPower;
            isJumping = true;
            isGrounded = false;
        }
        else
        {
            isFalling = true;
            isJumping = false;
            isGrounded = true;
        }
        //TODO: Exit the crouching state
        if (isCrouching)
            isCrouching = false;
        anim.SetBool("isCrouching", false);
        _capsulecol2d.size = originalCapsuleSize;
        moveSpeed = originalMS;
    }

    public void Crouch(InputAction.CallbackContext ctx)
    {
        //Start crouching
        if (!isCrouching)
        {
            isCrouching = true;
            anim.SetBool("isCrouching", true);
            _capsulecol2d.size = new Vector2(1.33f, 1); //Set the size of the collider so that it is suitable for crouching
            moveSpeed = crouchMS;
        }
    }

    public void Interaction(InputAction.CallbackContext ctx)
    {
        //Different functionalities of interactions
        GrabItem?.Invoke();
        ChooseGate?.Invoke();

    }

    public void PauseGame(InputAction.CallbackContext ctx)
    {
        //TODO: Pause the game when the Pause button on UI is pressed
    }

    //PLAYER'S MOVEMENTS

    public void Movement()
    {
        sr.transform.localScale = new Vector3(isFacingRight ? Mathf.Abs(sr.transform.localScale.x) : -Mathf.Abs(sr.transform.localScale.x), sr.transform.localScale.y, sr.transform.localScale.z);

        Vector2 playerVelocity = new Vector2(playerMovementDir.x * moveSpeed, rb2d.velocity.y);
        rb2d.velocity = playerVelocity;

        
        //Flip the player sprite
        if (playerVelocity.x > 0)
        {
            isFacingRight = true;
            anim.SetBool("isRunning", true);

        }
        else if (playerVelocity.x < 0)
        {
            isFacingRight = false;
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
