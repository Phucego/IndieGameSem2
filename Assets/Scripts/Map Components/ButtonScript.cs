using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    Animator anim;
   
    GameObject movingPlatformObj;
    public MovingPlatform movingPlatformScript;
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
        ;
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PushableObj"))
        {
           
            anim.SetBool("isButtonSteppedOn", true);
            AudioManager.Instance.PlaySoundEffect("Button_SFX");
            //Start moving the platform when the button is pressed
            Debug.Log("aaa");
            movingPlatformScript.OnActivePlatform(true);
           
           
        }
    }
    //When the player is staying on the button
    private void OnCollisionStay2D(Collision2D collision)
    {
        anim.SetBool("isPlayerStayOnButton", true);
        

    }

    //When the player exits
    private void OnCollisionExit2D(Collision2D collision)
    {
        movingPlatformScript.OnActivePlatform(false);
        anim.SetBool("isButtonSteppedOn", false);
        anim.SetBool("isPlayerStayOnButton", false);
    }
    //Start moving the points in the array of points set in the game
    public void InitMovingPlatform(Vector3 spawnPosition, Vector3[] movingPoint)
    {
        GameObject movingGO = Instantiate(movingPlatformObj);
        movingGO.transform.position = spawnPosition;
        movingGO.GetComponent<MovingPlatform>().InitMoving(movingPoint);       //Moving the platform
    }
}
