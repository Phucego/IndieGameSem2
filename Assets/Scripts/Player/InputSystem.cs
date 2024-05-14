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
    public bool isGrounded;
    public bool isJumping, isFacingRight, isInteractButtonPressed;
    [SerializeField] private bool isCrouching;


    public LayerMask platformLayer;

    public Transform groundChecking;
    [SerializeField] private Transform grabDetectPos, boxHoldingPos;

    //Floats
    private float jumpTimeCounter;
    public float jumpPower, moveSpeed, horizontal, jumpTime, groundCheckRadius;

    Vector2 playerMovementDir = Vector2.zero;
    ButtonScript jump;
    //Input actions
    public InputAction playerControls;
    PlayerAnimationStates _animStates;

    //ANIMATION STATES
    //Only use const if the variable will not change and it is fixed
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_RUN = "Player_Run";
    const string PLAYER_JUMP = "Player_Jump";
    const string PLAYER_FALLING = "Player_Falling";
    const string PLAYER_CROUCH = "Player_Crouch";

    // Start is called before the first frame update

    SpriteRenderer sr;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        _animStates = GetComponent<PlayerAnimationStates>();
        _capsulecol2d = GetComponent<CapsuleCollider2D>();
        Time.timeScale = 0.95f;


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
        
        if (isGrounded && !isJumping)
        {
           
            rb2d.velocity = Vector2.up * jumpPower;
            isJumping = true;
            
        }
        else
        {
            isJumping = false;
        }
        if(rb2d.velocity.y > 0)
        {
            _animStates.ChangeAnimStates(PLAYER_JUMP);
        }
      
       
    }

    public void Crouch(InputAction.CallbackContext ctx)
    {
        Debug.Log("is holding crouch");
        isCrouching = true;
        _animStates.ChangeAnimStates(PLAYER_CROUCH);
        
    }
    public void PauseGame(InputAction.CallbackContext ctx)
    {

    }

    //PLAYER'S MOVEMENTS

    public void Movement()
    {
        //sr.flipX = isFacingRight;
        sr.transform.localScale = new Vector3(isFacingRight ? Mathf.Abs(sr.transform.localScale.x) : -Mathf.Abs(sr.transform.localScale.x), sr.transform.localScale.y, sr.transform.localScale.z);

        Vector2 playerVelocity = new Vector2(playerMovementDir.x * moveSpeed, rb2d.velocity.y);
        rb2d.velocity = playerVelocity;



        //Flip the player sprite
        if (playerVelocity.x > 0)
        {
            isFacingRight = true;

        }
        else if (playerVelocity.x < 0)
        {
            isFacingRight = false;
            
        }

        if (playerVelocity.x > 0 || playerVelocity.x < 0)
        {
            _animStates.ChangeAnimStates(PLAYER_RUN);
            
        }
        else
        {
            _animStates.ChangeAnimStates(PLAYER_IDLE);
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
