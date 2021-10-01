using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectFlower : MonoBehaviour
{
    [SerializeField] private FlowerWall rightFlowerWall;

    private bool giftsAreColleted = false;
    private bool princeHasCross = false;
    
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && giftsAreColleted)
        {
            rightFlowerWall.ScaleUpFlower();
        }
    }

    public void SetGiftsAreCollected(bool state)
    {
        giftsAreColleted = true;
    }
}
