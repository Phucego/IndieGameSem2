using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Singleton
    public static PlayerController instance;

    private GameObject waterZone;
    
    Scene scene;

    SpriteRenderer sr;

    InputSystem _inputSystem;
    private void Awake()
    {
        //If there is an instance and it is not the player, then delete
        if(instance != null && instance != this)
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
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Water_Zone")
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 154, 194);
            _inputSystem.moveSpeed = 2f;
            _inputSystem.jumpPower = 1f;
            Debug.Log("is in water");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Water_Zone")
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            
        }
    }


}
