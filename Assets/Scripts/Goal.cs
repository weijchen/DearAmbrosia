using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _meetAudioClip;
    [SerializeField] private AudioClip _giftShowedAudioClip;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject prizes;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject environment;
    [SerializeField] private int clipPlayMaxCount = 5;

    private int clipPlayCount = 0;
    private SafeZone _safeZone;
    private GameManager _gameManager;

    private void Start()
    {
        prizes.SetActive(false);
        _safeZone = FindObjectOfType<SafeZone>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (clipPlayCount < clipPlayMaxCount)
            {
                _audioSource.clip = _meetAudioClip;
                _audioSource.Play();
            }
            _safeZone.SetRespawnPosition(spawnPosition);
            _audioSource.PlayOneShot(_giftShowedAudioClip);
            _gameManager.HideHandle();
            prizes.SetActive(true);
            //environment.SetActive(false);
            player.SetActive(false);
            clipPlayCount += 1;
        }
    }
}
