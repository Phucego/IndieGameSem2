using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TutorialSigns : MonoBehaviour
{
    [SerializeField] private Image interactIndicator;
    [SerializeField] private InputSystem _inputSystemObserve;
    public TextMeshPro tutText;

    private bool isInArea;
    #region Observer Pattern
    private void Awake()
    {
        if (_inputSystemObserve != null)
        {
            _inputSystemObserve.GrabItem_Event += ActivateTutorialText;
        }
    }

    private void OnDestroy()
    {
        if (_inputSystemObserve != null)
        {
            _inputSystemObserve.GrabItem_Event -= ActivateTutorialText;
        }
    }
    #endregion
    private void Start()
    {
        tutText.GetComponent<TextMeshPro>();
        tutText.enabled = false;
        interactIndicator.enabled = false;
        
    }
    public void ActivateTutorialText()
    {
        StartCoroutine(ActiveText());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            interactIndicator.enabled = true;
            isInArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactIndicator.enabled = false;
            isInArea = false;
        }
    }
    IEnumerator ActiveText()
    {
        if (isInArea)
        {
            tutText.enabled = true;
            yield return new WaitForSeconds(2f);
            tutText.enabled = false;
        }
    }
}
