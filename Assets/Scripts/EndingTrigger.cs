using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public GameObject LoveLetterCube;
    public GameObject ChocolateCube;
    public GameObject RoseCube;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _HEClip;
    [SerializeField] private AudioClip _BEClip;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.gameObject.tag == "LoveLetter")
        {
            Debug.Log("LoveLetter Received");
            LoveLetterCube.SetActive(false);
            _audioSource.PlayOneShot(_HEClip);
        }
        else if (other.gameObject.tag == "Chocolate")
        {
            Debug.Log("Chocolate Received");
            ChocolateCube.SetActive(false);
            _audioSource.PlayOneShot(_BEClip);
        }
        else if (other.gameObject.tag == "Rose")
        {
            Debug.Log("Rose Received");
            RoseCube.SetActive(false);
            _audioSource.PlayOneShot(_HEClip);
        }
    }
}
