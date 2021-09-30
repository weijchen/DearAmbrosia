using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectFlower : MonoBehaviour
{
    [SerializeField] private GameObject connectedObject;

    private bool princeHasCross = false;
    
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        connectedObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            connectedObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
