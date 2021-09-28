using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _meetAudioClip;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject prizes;

    private SafeZone _safeZone;

    private void Start()
    {
        prizes.SetActive(false);
        _safeZone = FindObjectOfType<SafeZone>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            _audioSource.PlayOneShot(_meetAudioClip);
            _safeZone.SetRespawnPosition(spawnPosition);
            prizes.SetActive(true);
        }    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.transform.tag == "Player")
    //     {
    //         _audioSource.PlayOneShot(_meetAudioClip);
    //         _safeZone.SetRespawnPosition(spawnPosition);
    //         prizes.SetActive(true);
    //     }
    // }
}
