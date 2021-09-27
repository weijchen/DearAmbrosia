using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiItemController : MonoBehaviour
{
    [SerializeField] private GameObject ItemCollection;
    // [SerializeField] private AudioSource _audioClip;
    
    //public GameObject OpenTip;
    private GameManager _gameManager;
    private int itemCollected = 0;
    private int targetItemAmount = 3;
    

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        ItemCollection.SetActive(false);
    }

    private void Update()
    {
        if (itemCollected == targetItemAmount)
        {
            CollectAllItems();
        }
    }

    private void CollectAllItems()
    {
        _gameManager.AddGiftCollected();
        ItemCollection.SetActive(true);
    }

    public void CollectItem()
    {
        itemCollected += 1;
        Debug.Log("Collected rose: " + itemCollected + " / " + targetItemAmount);
    }
}
