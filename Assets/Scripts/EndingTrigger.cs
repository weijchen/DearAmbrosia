using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    // [SerializeField] private AudioSource _audioSource;
    // [SerializeField] private AudioClip _HEClip;
    // [SerializeField] private AudioClip _BEClip;
    [SerializeField] private GameObject LoveLetterObject;
    [SerializeField] private GameObject ChocolateObject;
    [SerializeField] private GameObject RoseObject;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        LoveLetterObject.SetActive(false);
        ChocolateObject.SetActive(false);
        RoseObject.SetActive(false);
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "LoveLetter")
    //     {
    //         Debug.Log("LoveLetter Received");
    //         _audioSource.PlayOneShot(_HEClip);
    //         LoveLetterObject.SetActive(true);
    //         _gameManager.ShowEndingAnim(0);
    //     }
    //     else if (other.gameObject.tag == "Chocolate")
    //     {
    //         Debug.Log("Chocolate Received");
    //         _audioSource.PlayOneShot(_BEClip);
    //         ChocolateObject.SetActive(true);
    //         _gameManager.ShowEndingAnim(1);
    //
    //     }
    //     else if (other.gameObject.tag == "Rose")
    //     {
    //         Debug.Log("Rose Received");
    //         _audioSource.PlayOneShot(_HEClip);
    //         RoseObject.SetActive(true);
    //         _gameManager.ShowEndingAnim(2);
    //     }
    // }
}
