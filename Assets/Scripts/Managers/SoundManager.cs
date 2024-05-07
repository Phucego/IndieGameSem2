using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]     //The Sound Manager will always requires an audio source
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    [SerializeField] AudioClip[] audioClips;

    AudioSource _audioSource;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    //This only applies to sounds that plays one time
    public static void PlaySound(SoundType sound, float volume = 1)
    {
        //Pass through the audio clips and enums and plays depends on the volume 
        _instance._audioSource.PlayOneShot(_instance.audioClips[(int)sound], volume);
    } 
}

public enum SoundType { FOOTSTEPS, DROP_PICKUP, JUMP, PICKUP,  IN_WATER, JUMPPAD }
