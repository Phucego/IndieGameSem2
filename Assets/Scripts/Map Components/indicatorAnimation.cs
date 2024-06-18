using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorAnimation : MonoBehaviour
{
    public TutorialSigns m_TutorialSigns;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (m_TutorialSigns.instance.isInArea)
        {
            
            anim.SetBool("isPlayerInArea", true);
        }
        else if(!m_TutorialSigns.instance.isInArea)
        {
            anim.SetBool("isPlayerInArea", false);
        }
    }

    IEnumerator PoppingUpIndicator()
    {
        anim.SetTrigger("triggerPopUp");
        yield return new WaitForSeconds(2f);
    }
}
