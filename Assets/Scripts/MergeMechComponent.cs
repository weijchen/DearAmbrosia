using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeMechComponent : MonoBehaviour
{
    [SerializeField] private Material InitialdMaterial;
    [SerializeField] private Material CollidedMaterial;
    [SerializeField] private MergeMech _mergeMech;
    [SerializeField] private string aOrB;
    
    private GameObject touchObject = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (aOrB.ToLower() == "a")
            {
                _mergeMech.SetATouch(true);
                touchObject = other.gameObject;
                _mergeMech.SetAMat(CollidedMaterial);
            }
            if (aOrB.ToLower() == "b")
            {
                _mergeMech.SetBTouch(true);
                touchObject = other.gameObject;
                _mergeMech.SetBMat(CollidedMaterial);
            }
        }    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.transform.tag == "Player")
    //     {
    //         if (aOrB.ToLower() == "a")
    //         {
    //             _mergeMech.SetATouch(false);            
    //             touchObject = null;
    //             _mergeMech.SetAMat(InitialdMaterial);
    //         }
    //         if (aOrB.ToLower() == "b")
    //         {
    //             _mergeMech.SetBTouch(false);
    //             touchObject = null;
    //             _mergeMech.SetBMat(InitialdMaterial);
    //
    //         }
    //     }
    // }

    public GameObject GetTouchObject()
    {
        return touchObject;
    }
}
