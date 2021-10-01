using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Transform respawnPosition;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioClip princePickClip;
    
    private bool isTouched;
    private SafeZone _safeZone;
    private GameManager _gameManager;
    private SoundEffectManager _soundEffectManager;

    void Start()
    {
        _safeZone = FindObjectOfType<SafeZone>();
        _gameManager = FindObjectOfType<GameManager>();
        _soundEffectManager = FindObjectOfType<SoundEffectManager>();
        isTouched = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isTouched)
            {
                isTouched = true;
                _safeZone.SetRespawnPosition(respawnPosition);
                _gameManager.AddGiftCollected();
                _soundEffectManager.PlayAudioClip(_audioClip);
                _soundEffectManager.PlayAudioClip(princePickClip);
                Destroy(gameObject);
            }
        }
    }
}
