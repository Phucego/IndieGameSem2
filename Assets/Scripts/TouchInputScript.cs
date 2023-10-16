using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputScript : MonoBehaviour
{
    Touch touchInput;
    Vector2 touchInputPos;
    public TouchInputScript instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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

        //while the player holding on the screen
        if(touchInput.phase == TouchPhase.Stationary)
        {
            Ray ray = Camera.main.ScreenPointToRay(touchInputPos);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))      //out syntax is for output only
            {
                if(hit.transform == transform)
                {
                    
                }
            }
            
        }
        //while the player release from the screen
        if(touchInput.phase == TouchPhase.Ended)
        {

            
       
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
