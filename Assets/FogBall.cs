using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FogBall : MonoBehaviour
{
    [SerializeField] private Transform fogCenterPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private float destroyDist = 0.03f;
   
    private Material fogMaterial;
    private bool isPlayerEnter = false;
    private float radius = 0f;

    void Start()
    {
        fogMaterial = GetComponent<MeshRenderer>().material;
    }
    

    void Update()
    {
        if (isPlayerEnter)
        {
            AdjustAlpha();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            isPlayerEnter = true;
            radius = Vector3.Distance(other.transform.position, transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            isPlayerEnter = false;
        }
    }

    private void AdjustAlpha()
    {
        float dist = Vector3.Distance(player.transform.position , fogCenterPoint.transform.position);
        
        if (dist > destroyDist)
        {
            Color color = fogMaterial.color;
            color.a = dist / radius;
            fogMaterial.color = color;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
