using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IPickable
{

    public void ObjectDrop(Transform boxHolderPos, Transform grabDetection)
    {
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        //gameObject = null;
    }

    public void ObjectPickUp(Transform grabDetection, Transform boxHolderPos)
    {
       
        //When the player picking up the obj
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true; //Hold the position of the obj
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.transform.parent = boxHolderPos;
        gameObject.transform.position = boxHolderPos.position;
    }
}


   
