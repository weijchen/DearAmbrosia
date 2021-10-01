using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
}
