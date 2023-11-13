using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gate : MonoBehaviour
{
    
    InputSystem inputSystemScript;

    // Start is called before the first frame update
    void Start()
    {
        inputSystemScript = FindObjectOfType<InputSystem>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(inputSystemScript.isInteractButtonPressed)
        {
            Debug.Log("You miss a key dumbass");
        }
    }
}
