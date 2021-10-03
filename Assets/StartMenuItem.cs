using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuItem : MonoBehaviour
{
    private StartMenu _startMenu;
    
    void Start()
    {
        _startMenu = FindObjectOfType<StartMenu>();
    }

    private void OnCollisionEnter(Collision other)
    {
        _startMenu.SetItemHasCollect(true);
        Destroy(gameObject);
    }
}
