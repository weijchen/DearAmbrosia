using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Material CollidedMaterial;
    [SerializeField] private GameObject GiftBox;
    [SerializeField] private GameObject LoveLetter;

    private bool hasTriggered = false;
    
    void Start()
    {
        LoveLetter.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!hasTriggered)
            {
                GiftBox.SetActive(false);
                LoveLetter.SetActive(true);
                gameObject.GetComponent<MeshRenderer>().material = CollidedMaterial;
                hasTriggered = true;
            }
        }
    }
}
