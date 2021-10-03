using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPartRecoverZone : MonoBehaviour
{
    [SerializeField] private Transform respawnPosition;

    private bool hasKeyCollected = false;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool hasKeyCollect = _gameManager.keyGot;
        if (other.transform.tag == "Player" && !hasKeyCollect)
        {
            other.transform.position = respawnPosition.position;
        }
    }
}
