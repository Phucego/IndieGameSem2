using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStateEnter_Audio : StateMachineBehaviour
{
    //Change sound in the animator (enter audio)
    [SerializeField] private SoundType _soundType;

    [SerializeField, Range(0, 1)] private float volume = 1;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManager.PlaySound(_soundType, volume);
    }
}
