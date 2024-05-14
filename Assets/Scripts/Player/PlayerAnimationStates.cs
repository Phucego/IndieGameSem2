using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStates : MonoBehaviour
{
    Animator anim;
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //The player starts with idle anim
        anim.Play("Player_Idle");
    }
    public void ChangeAnimStates(string newState)
    {
        //Stop the same anim from interrupting
        if(currentState == newState)
        {
            return;
        }
        //Play the new animation
        anim.Play(newState);

        currentState = newState;

    }

      
   
}
