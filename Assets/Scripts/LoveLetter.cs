using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLetter : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    public GameObject OpenedLetter;

    //[SerializeField] private AudioSource _audioClip;
    //public GameObject OpenTip;
    
    private GameManager _gameManager;
    private SafeZone _safeZone;
    private bool isTouched = false;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _safeZone = FindObjectOfType<SafeZone>();
        OpenedLetter.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTouched = true;
            OpenedLetter.SetActive(true);
            _gameManager.AddGiftCollected();
            _safeZone.SetRespawnPosition(spawnPosition);
            Destroy(gameObject);
        }
    }
}
