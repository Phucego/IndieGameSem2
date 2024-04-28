using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Singleton
    public static PlayerController instance;
   
    
  
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

    

    
    
}
