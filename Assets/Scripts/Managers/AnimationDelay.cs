using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelay : MonoBehaviour
{
    public int animationDelay = 2;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        StartCoroutine(AnimationDelayFunc());
    }
    IEnumerator AnimationDelayFunc()
    {
        anim.SetBool("isShining", false);

        yield return new WaitForSeconds(animationDelay);
        anim.SetBool("isShining", true);
    }
}
