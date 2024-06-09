using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesMainMenu : MonoBehaviour
{
    [SerializeField] private float _timeBetweenAnim = 2;
    private Animator anim;
  
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(LeavesAnimDelay());
    }

    IEnumerator LeavesAnimDelay()
    {
        anim.SetTrigger("LeavesBlow");
        anim.SetBool("canBlow", true);
       
        yield return new WaitForSeconds(_timeBetweenAnim);
        anim.SetBool("canBlow", false);
    }
}
