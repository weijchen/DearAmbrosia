using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLetter : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private GameObject OpenedLetter;

    private bool isTouched = false;

    private SoundEffectManager _soundEffectManager;
    private GameManager _gameManager;
    private SafeZone _safeZone;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _safeZone = FindObjectOfType<SafeZone>();
        _soundEffectManager = FindObjectOfType<SoundEffectManager>();
        OpenedLetter.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTouched = true;
            OpenedLetter.SetActive(true);
            _gameManager.AddGiftCollected();
            _safeZone.SetRespawnPosition(spawnPosition);
            _soundEffectManager.PlayAudioClip(_audioClip);
            Destroy(gameObject);
        }
    }
}
