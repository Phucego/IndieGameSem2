using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextManager : MonoBehaviour
{
 
    public static TutorialTextManager instance;
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
    public void ShowText()
    {
        //gameObject.transform
    }
    public void DisableText()
    {
        gameObject.SetActive(false);

    }
}
