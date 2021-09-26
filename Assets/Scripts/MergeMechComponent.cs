using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeMechComponent : MonoBehaviour
{
    [SerializeField] private MergeMech _mergeMech;
    [SerializeField] private string aOrB;
    
    private GameObject touchObject = null;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            if (aOrB.ToLower() == "a")
            {
                _mergeMech.SetATouch(true);
                touchObject = other.gameObject;
            }
            if (aOrB.ToLower() == "b")
            {
                _mergeMech.SetBTouch(true);
                touchObject = other.gameObject;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            if (aOrB.ToLower() == "a")
            {
                _mergeMech.SetATouch(false);            
                touchObject = null;
            }
            if (aOrB.ToLower() == "b")
            {
                _mergeMech.SetBTouch(false);
                touchObject = null;
            }
        }
    }

    public GameObject GetTouchObject()
    {
        return touchObject;
    }
}
