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
    private GameObject grabbedObj;
    //Player start picking up the obj
    public void Interaction(InputAction.CallbackContext ctx)
    {
        if (grabbedObj == null)
        {
            //---- PICKING OBJECTS ---- \\
            //Shoot a ray to the right and check if there is a grabbable obj
            RaycastHit2D grabCheck = Physics2D.Raycast(grabDectection.position, Vector2.right * transform.localScale, rayDistance);
            if (grabCheck.collider != null && grabCheck.collider.tag == "PushableObj")
            {

                grabbedObj = grabCheck.collider.gameObject;
                //When the player picking up the obj

                grabbedObj.GetComponent<Rigidbody2D>().isKinematic = true; //Hold the position of the obj
                grabbedObj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                grabbedObj.GetComponent<BoxCollider2D>().enabled = false;
                grabbedObj.transform.parent = boxHolderPos;
                grabbedObj.transform.position = boxHolderPos.position;


            }

        }
        else
        {
            grabbedObj.transform.parent = null;
            grabbedObj.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            grabbedObj.GetComponent<BoxCollider2D>().enabled = true;
            grabbedObj = null;
        }

    }
    //When the player releases the obj
    public void CancelInteract(InputAction.CallbackContext ctx)
    {
       

    }
}
