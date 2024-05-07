using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable 
{
    void ObjectPickUp(Transform boxHolderPos, Transform grabDetection);
    void ObjectDrop(Transform boxHolderPos, Transform grabDetection);

}
