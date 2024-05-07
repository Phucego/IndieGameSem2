using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStateExit_Audio : StateMachineBehaviour
{
    ///Change sound in the animator (exit audio)
    [SerializeField] private SoundType _soundType;

    [SerializeField, Range(0, 1)] private float volume = 1;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManager.PlaySound(_soundType, volume);
    }
}
