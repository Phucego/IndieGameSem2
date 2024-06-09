using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    private Scene scene;
    
    void Awake()
    {
        /*DontDestroyOnLoad(this.gameObject);*/
        scene = SceneManager.GetActiveScene();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WinCondition"))
        {
            SceneManager.LoadScene(scene.buildIndex + 1);   
        }
    }
}
