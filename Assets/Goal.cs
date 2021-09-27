using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _meetAudioClip;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            _audioSource.PlayOneShot(_meetAudioClip);
        }
    }
}
