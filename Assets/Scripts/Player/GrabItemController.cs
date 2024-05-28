using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GrabItemController : MonoBehaviour
{
    //Picking up objects variables
    public Transform grabDetection, boxHolderPos;
    public float rayDistance;
    [SerializeField] private bool isInteractButtonPressed;
    private GameObject grabbedObj;

    [SerializeField] private InputSystem _inputSystemObserve;

    private float boxHoldingMS = 4.5f, originalMS;

    #region Observer Pattern
    private void Awake()
    {
        if(_inputSystemObserve != null)
        {
            _inputSystemObserve.GrabItem_Event += GrabbingItem; 
        }
    }

    private void OnDestroy()
    {
        if (_inputSystemObserve != null)
        {
            _inputSystemObserve.GrabItem_Event -= GrabbingItem;
        }
    }
    #endregion

    private void Start()
    {
        originalMS = _inputSystemObserve.moveSpeed;
    }
    //Player start picking up the obj
    public void GrabbingItem()
    {
        if (grabbedObj == null)
        {
            //---- PICKING OBJECTS ---- \\
            //Shoot a ray to the right and check if there is a grabbable obj
            RaycastHit2D grabCheck = Physics2D.Raycast(grabDetection.position, Vector2.right * transform.localScale, rayDistance);
            if (grabCheck.collider != null && grabCheck.collider.tag == "PushableObj")
            {

                grabbedObj = grabCheck.collider.gameObject;
                //When the player picking up the obj

                grabbedObj.GetComponent<Rigidbody2D>().isKinematic = true; //Hold the position of the obj
                grabbedObj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                grabbedObj.GetComponent<BoxCollider2D>().enabled = false;
                grabbedObj.transform.parent = boxHolderPos;
                grabbedObj.transform.position = boxHolderPos.position;
                _inputSystemObserve.moveSpeed = boxHoldingMS;
                
            }
        }
        //Dropping the item
        else
        {
            grabbedObj.transform.parent = null;
            grabbedObj.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            grabbedObj.GetComponent<BoxCollider2D>().enabled = true;
            grabbedObj = null;
            _inputSystemObserve.moveSpeed = originalMS;
        }

    }
   
}
