using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootStepAudio : MonoBehaviour
{
    public void PlayerSound()
    {
        if (gameObject.CompareTag("GrassGround"))
        {
            SoundManager.PlaySound(SoundType.FOOTSTEPS);
        }
    }
}
