using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollections : MonoBehaviour
{
    [SerializeField] [Range(0, 2)] private int endingAnimSelection;
    [SerializeField] private GameObject epilogueAnimObj;
    [SerializeField] private AudioClip _endingClip;

    private GameManager _gameManager;
    private AudioSource _audioSource;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        epilogueAnimObj.SetActive(false);
    }
    
    public void DetectHandHover()
    {
        epilogueAnimObj.SetActive(true);
        _gameManager.ShowEndingAnim(endingAnimSelection);
        _audioSource.PlayOneShot(_endingClip);
    }
}
