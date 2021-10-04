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
}
