using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    [SerializeField] private Transform respawnPosition;

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.position = respawnPosition.position;
        }
    }

    public void SetRespawnPosition(Transform newPosition)
    {
        respawnPosition = newPosition;
    }
}
