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
    private Animator anim;
    public bool isInArea; 
    public TutorialSigns instance;
    #region Design Pattern
    private void Awake()
    {
        if (_inputSystemObserve != null)
        {
            _inputSystemObserve.GrabItem_Event += ActivateTutorialText;
        }
        //If there is an instance and it is not the player, then delete
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
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
        anim = GetComponent<Animator>();
    }
    public void ActivateTutorialText()
    {
        StartCoroutine(ActiveText());
        anim.SetTrigger("triggerTextPopUp");
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
