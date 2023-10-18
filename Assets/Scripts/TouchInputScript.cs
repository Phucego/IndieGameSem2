using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputScript : MonoBehaviour
{
    Touch touchInput;
    Vector2 touchInputPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Fixed Update for physics code.
    private void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            //Get touch using GetTouch
            //each touch will be put in an "touch" array starting with 0
            touchInput = Input.GetTouch(0);

            //touch position
            touchInputPos = new Vector2(touchInput.position.x, touchInput.position.y);
            //Debug.Log(touchInputPos);
        }

        OnMouseDrag();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //Dragging objects 
    void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -1 * (Camera.main.transform.position.z));
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = objectPos;
    }
}
