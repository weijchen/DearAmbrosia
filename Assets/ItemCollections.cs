using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollections : MonoBehaviour
{
    [SerializeField] [Range(0, 2)] private int endingAnimSelection;
    [SerializeField] private GameObject epilogueAnimObj;
    [SerializeField] private AudioClip _endingClip;
    [SerializeField] private AudioSource _audioSource;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        epilogueAnimObj.SetActive(false);
    }
    
    public void DetectHandClick()
    {
        epilogueAnimObj.SetActive(true);
        _gameManager.ShowEndingAnim(endingAnimSelection);
        _audioSource.PlayOneShot(_endingClip);
    }
}
