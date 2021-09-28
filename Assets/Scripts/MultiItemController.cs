using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiItemController : MonoBehaviour
{
    [SerializeField] private Transform respawnPosition;

    private int itemCollected = 0;
    private int targetItemAmount = 3;
    private bool hasItemCollect = false;

    private GameManager _gameManager;
    private SafeZone _safeZone;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _safeZone = FindObjectOfType<SafeZone>();
    }

    private void Update()
    {
        if (itemCollected == targetItemAmount && !hasItemCollect)
        {
            CollectAllItems();
        }
    }

    private void CollectAllItems()
    {
        _gameManager.AddGiftCollected();
        _safeZone.SetRespawnPosition(respawnPosition);
        hasItemCollect = true;
    }

    public void CollectItem()
    {
        itemCollected += 1;
        Debug.Log("Collected rose: " + itemCollected + " / " + targetItemAmount);
    }
}
