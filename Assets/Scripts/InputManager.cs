
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
    }
    private void OnEnable()
    {
        touchControls.Enable();
    }
    private void OnDisable()
    {
        touchControls.Disable();
    }
    private void Start()
    {
        //ctx == context 
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }
    void StartTouch(InputAction.CallbackContext context)
    {

    }
    void EndTouch(InputAction.CallbackContext context)
    {

    }
}
