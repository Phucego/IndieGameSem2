using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GrabItemController : MonoBehaviour
{
    //Picking up objects variables
    public Transform grabDectection, boxHolderPos;
    public float rayDistance;
    [SerializeField] private bool isInteractButtonPressed;
    
    //Player start picking up the obj
    public void Interaction(InputAction.CallbackContext ctx)
    {
        //---- PICKING OBJECTS ---- \\
        //Shoot a ray to the right and check if there is a grabbable obj
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDectection.position, Vector2.right * transform.localScale, rayDistance);
        if (grabCheck.collider != null && grabCheck.collider.tag == "PushableObj")
        {
            isInteractButtonPressed = true;
            //When the player picking up the obj
            if (isInteractButtonPressed)        //When the button is pressed, set the position of the obj to the box holding position on the player
            {
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;   //Hold the position of the obj
                grabCheck.collider.gameObject.transform.parent = boxHolderPos;
                grabCheck.collider.gameObject.transform.position = boxHolderPos.position;
            }
        }

    }
    //When the player releases the obj
    public void CancelInteract(InputAction.CallbackContext ctx)
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDectection.position, Vector2.right * transform.localScale, rayDistance);
        isInteractButtonPressed = false;
        if (!isInteractButtonPressed)
        {
            grabCheck.collider.gameObject.transform.parent = null;
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
