using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Singleton
    public static PlayerController instance;
    public Transform respawnPoint;

    Scene scene;
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

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene(); //Get the currently active scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Kill the player then set the position back to the respawn position
    public void KillPlayer()
    {
        gameObject.transform.position = respawnPoint.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WinCondition"))
        {
            Debug.Log(scene.name);
            SceneManager.LoadScene(scene.buildIndex + 1);   //Change to the next scene w/o hardcoding
        }
    }
}
