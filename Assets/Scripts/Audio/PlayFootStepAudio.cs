using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootStepAudio : MonoBehaviour
{
    public void PlayerSound()
    {
        SoundManager.PlaySound(SoundType.FOOTSTEPS);
    }
}
