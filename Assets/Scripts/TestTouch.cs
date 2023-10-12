using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouch : MonoBehaviour
{

    private InputManager inputmanager;
    private Camera cameraMain;
    private void Awake()
    {
        //Singleton instance
        inputmanager = InputManager.Instance;
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        inputmanager.OnStartTouch += Move;
    }
    private void OnDisable()
    {
        inputmanager.OnEndTouch -= Move;
    }

    
    public void Move(Vector2 screenPos, float time)
    {
        //nearClipPlane is the distance of the near clipping plane
        //from the Camera in world units
        Vector3 screenCoordinates = new Vector3(screenPos.x, screenPos.y, cameraMain.nearClipPlane);
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);

        //For the char to stays on the plane
        worldCoordinates.z = 0;
        transform.position = worldCoordinates;
    }
}
