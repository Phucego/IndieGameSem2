using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GateHandler : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystemObserve;

    [SerializeField] private GameObject currentGate;
    [SerializeField] private float circleRadius;

    RaycastHit2D gateCheck;

    public Image[] _buttonIndicator;

    private bool _canPressGate;
    #region Observer Pattern
    private void Awake()
    {
        if (_inputSystemObserve != null)
        {
            _inputSystemObserve.ChooseGate_Event += OnGateOpened;
        }
    }

    private void OnDestroy()
    {
        if (_inputSystemObserve != null)
        {
            _inputSystemObserve.ChooseGate_Event -= OnGateOpened;
        }
    }

    #endregion
    private void Update()
    {
        OnGateOpened();
    }

    public void OnGateOpened()
    {
        gateCheck = Physics2D.CircleCast(transform.position, circleRadius, Vector2.one);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _canPressGate = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        _canPressGate = true;
        if(gateCheck == currentGate && _canPressGate)
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

    /*void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.transform.position, circleRadius);
    }*/
}
