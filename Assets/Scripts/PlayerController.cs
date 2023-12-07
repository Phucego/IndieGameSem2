using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Singleton
    public static PlayerController instance;
    public Transform respawnPoint;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KillPlayer()
    {
        gameObject.transform.position = respawnPoint.transform.position;
    }
}
