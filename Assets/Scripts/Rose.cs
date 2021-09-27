using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour
{
    [SerializeField] private MultiItemController _multiItemController;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            _multiItemController.CollectItem();
            Destroy(gameObject);
        }
    }
}
