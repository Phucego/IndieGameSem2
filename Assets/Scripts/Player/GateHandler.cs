using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHandler : MonoBehaviour
{
    InputSystem _inputSystemObserve;

    [SerializeField] private GameObject currentGate;
    [SerializeField] private float circleRadius;

    RaycastHit2D gateCheck;

    #region Observer Pattern
    private void Awake()
    {
        if (_inputSystemObserve != null)
        {
            _inputSystemObserve.ChooseGate += OnGateOpened;
        }
    }

    private void OnDestroy()
    {
        if (_inputSystemObserve != null)
        {
            _inputSystemObserve.ChooseGate -= OnGateOpened;
        }
    }

    #endregion
    private void Update()
    {
       
    }

    public void OnGateOpened()
    {
        gateCheck = Physics2D.CircleCast(transform.position, circleRadius, Vector2.one);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gateCheck == currentGate)
        {
            LevelSelectManager.instance.OnGateSelected(currentGate);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(gateCheck != currentGate)
        {
            return;
        }
    }
}
