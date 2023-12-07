using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Button{
 *  position: 
 *  moving: {
 *      position:
 *      movingPoint[Vector3, Vecotor3, Vector3]
 *  }
 * }
 */

public class Test : MonoBehaviour
{
    public GameObject buttonPrefab;
    private Vector3 buttonSpawnPosition;
    private Vector3 movingSpawnPosition;
    private Vector3[] movingPoint;

    // Start is called before the first frame update
    void Start()
    {
        buttonSpawnPosition = new Vector3(-8.8f, 3.88f, 0f);
        movingSpawnPosition = new Vector3(7.1f, 1.1f, 0f);

        GameObject buttonGO = Instantiate(buttonPrefab);
        buttonGO.transform.position = buttonSpawnPosition;
        buttonGO.GetComponent<ButtonScript>().InitMovingPlatform(movingSpawnPosition, movingPoint);
    }
}
