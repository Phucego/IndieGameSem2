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
    [SerializeField] private LayerMask m_GateMask;

    RaycastHit2D gateCheck;
    
  
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


    public void OnGateOpened()
    {
        
        gateCheck = Physics2D.CircleCast(transform.position, circleRadius, Vector2.one, 1000, m_GateMask);
        if (gateCheck)
        {
            currentGate = gateCheck.collider.gameObject;
            if (gateCheck.collider.GetComponent<Gate_Handle>() != null)
            {
                gateCheck.collider.GetComponent<Gate_Handle>().OnLoadLevel();
            }
        }
    }
}
