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
    [SerializeField] private bool isCrouching, isTurning;


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
    public event Action GrabItem_Event;
    public event Action ChooseGate_Event;

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

        //TODO: Check velocity for animation
        anim.SetFloat("YAxisVelocity", rb2d.velocity.y);
        anim.SetFloat("ToIdleState", rb2d.velocity.y);


    }

    //Handle Jump inputs
    public void Jump(InputAction.CallbackContext ctx)
    {
        //TODO: Check if the player is on the ground, then jump
        groundCheckCircle = Physics2D.OverlapCircle(groundChecking.transform.position, groundCheckRadius, platformLayer);


        //TODO: If all of these conditions are met, the player can jump
        if (!isCrouching && !isJumping && groundCheckCircle)
        {
            rb2d.velocity = Vector2.up * jumpPower;
            isGrounded = false;
        }

        //TODO: Check if it is jumping or falling
        if (!isGrounded && isJumping && !isFalling && rb2d.velocity.y > 0)
        {
            isJumping = true;
            isFalling = false;
        }
        else if (!isGrounded && !isJumping && isFalling && rb2d.velocity.y < 0)
        {
            isJumping = false;
            isFalling = true;

        }
        else
        {
            isGrounded = true;
            isJumping = false;
            isFalling = false;
        }



    }

    public void Crouch(InputAction.CallbackContext ctx)
    {
        var originalCapsuleSize = _capsulecol2d.size = new Vector2(1.33f, 2.06f);
        //Start crouching
        if (!isCrouching)
        {
            isCrouching = true;
            anim.SetBool("isCrouching", true);
            _capsulecol2d.size = new Vector2(1.33f, 1); //Set the size of the collider so that it is suitable for crouching
            moveSpeed = crouchMS;
        }
        else
        {
            //TODO: Exit the crouching state
            if (isCrouching)
                isCrouching = false;
            anim.SetBool("isCrouching", false);
            _capsulecol2d.size = originalCapsuleSize;
            moveSpeed = originalMS;
        }
    }

    public void Interaction(InputAction.CallbackContext ctx)
    {
        //Different functionalities of interactions
        GrabItem_Event?.Invoke();
        ChooseGate_Event?.Invoke();

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


        //TODO: The player can only play animation when on the ground, if not moving then start idle anim
        if (playerVelocity.x > 0 && !isJumping && !isFalling && !isTurning)
        {
            isFacingRight = true;
            anim.SetBool("isRunning", true);

            


        }
        else if (playerVelocity.x < 0 && !isJumping && !isFalling && !isTurning)
        {
            isFacingRight = false;
            anim.SetBool("isRunning", true);
           
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        //TODO: Check for crouch walk animation
        if (playerVelocity.x > 0 || playerVelocity.x < 0 && isCrouching)
        {
            anim.SetBool("isCrouchWalking", true);

        }
        else
        {
            anim.SetBool("isCrouchWalking", false);
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