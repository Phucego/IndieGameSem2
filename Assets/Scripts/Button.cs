using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Animator anim;
    public bool isButtonPressed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isButtonPressed = true;
            anim.SetBool("isButtonSteppedOn", true);
       
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        anim.SetBool("isPlayerStayOnButton", true);

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isButtonPressed = false;
        anim.SetBool("isButtonSteppedOn", false);
        anim.SetBool("isPlayerStayOnButton", false);
        
    }
}
