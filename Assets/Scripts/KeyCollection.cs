using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollection : MonoBehaviour
{
    [SerializeField] private Transform respawnPosition;
    [SerializeField] private AudioClip _audioClip;
    
    [Header("Door Mechanic")]
    [SerializeField] private GameObject wallToDestroy;
    [SerializeField] private Material OpenMaterial;
    [SerializeField] private AudioClip doorSpawnClip;
    
    
    private SafeZone _safeZone;
    private GameManager _gameManager;
    private SoundEffectManager _soundEffectManager;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _safeZone = FindObjectOfType<SafeZone>();
        _soundEffectManager = FindObjectOfType<SoundEffectManager>();
        _gameManager.keyGot = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!_gameManager.keyGot)
            {
                _gameManager.keyGot = true;
                _safeZone.SetRespawnPosition(respawnPosition);
                _soundEffectManager.PlayAudioClip(_audioClip);
                gameObject.SetActive(false);
                AfterGotKey();
            }
        }
    }

    void AfterGotKey()
    {
        _soundEffectManager.PlayAudioClip(doorSpawnClip);
        wallToDestroy.GetComponent<MeshRenderer>().material = OpenMaterial;
    }
}
