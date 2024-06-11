using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Singleton
    public static PlayerController instance;

    private GameObject waterZone, currentGate;


    Scene scene;

    SpriteRenderer sr;

    InputSystem _inputSystem;
    private Rigidbody2D rb2d;

    private float circleRadius;

    private void Awake()
    {
        //If there is an instance and it is not the player, then delete
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        _inputSystem = GetComponent<InputSystem>();
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Water_Zone")
        {
            //When the player enters the water zone
            GetComponent<SpriteRenderer>().color = new Color(0, 154, 194);  //turn the player to blue
            _inputSystem.moveSpeed = 2f;
            _inputSystem.jumpPower = 5f;
            rb2d.mass = 0.01f;
            rb2d.gravityScale = 3f;
            _inputSystem.groundCheckRadius = 20f;
        }

        if(collision.gameObject.name.Contains("Tutorial_"))
        {
            TutorialTextManager.instance.ShowText();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //When the player exit the water zone
        if (other.gameObject.name == "Water_Zone")
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);    //default color
            _inputSystem.moveSpeed = 7f;
            _inputSystem.jumpPower = 25f;
            rb2d.mass = 0.75f;
            rb2d.gravityScale = 8f;
            _inputSystem.groundCheckRadius = 0.3f;

        }
        if(other.gameObject.name.Contains("Tutorial_"))
        {
            TutorialTextManager.instance.DisableText();
        }
    }

    

}
