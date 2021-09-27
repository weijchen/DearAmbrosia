using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private GameObject ItemCollection;

    [SerializeField] private Transform respawnPosition;
    // [SerializeField] private AudioSource _audioClip;
    
    //public GameObject OpenTip;
    private bool isTouched;
    private SafeZone _safeZone;

    void Start()
    {
        _safeZone = FindObjectOfType<SafeZone>();
        isTouched = false;
        ItemCollection.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isTouched)
            {
                isTouched = true;
                Destroy(gameObject);
                // _audioClip.Play();
                _safeZone.SetRespawnPosition(respawnPosition);
                ItemCollection.SetActive(true);    
            }
        }
    }
}
