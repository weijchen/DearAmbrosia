using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollection : MonoBehaviour
{
    [SerializeField] private Transform respawnPosition;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private GameObject wallToDestroy;
    [SerializeField] private Material OpenMaterial;
    
    
    private SafeZone _safeZone;
    private GameManager _gameManager;
    private SoundEffectManager _soundEffectManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _safeZone = FindObjectOfType<SafeZone>();
        _soundEffectManager = FindObjectOfType<SoundEffectManager>();
        _gameManager.keyGot = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        wallToDestroy.GetComponent<MeshRenderer>().material = OpenMaterial;
    }
}
