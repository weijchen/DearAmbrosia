using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBottom : MonoBehaviour
{
    [SerializeField] private float yOffset = 0.2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + yOffset,
                other.transform.position.z);
        }
    }
}
