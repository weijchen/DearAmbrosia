using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _HEClip;
    [SerializeField] private AudioClip _BEClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LoveLetter")
        {
            Debug.Log("LoveLetter Received");
            _audioSource.PlayOneShot(_HEClip);
        }
        else if (other.gameObject.tag == "Chocolate")
        {
            Debug.Log("Chocolate Received");
            _audioSource.PlayOneShot(_BEClip);
        }
        else if (other.gameObject.tag == "Rose")
        {
            Debug.Log("Rose Received");
            _audioSource.PlayOneShot(_HEClip);
        }
    }
}
