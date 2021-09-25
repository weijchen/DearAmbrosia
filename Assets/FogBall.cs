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
    private MeshRenderer _meshRenderer;
    [SerializeField] private float destroyDist = 0.03f;
    private bool isPlayerEnter = false;
    
    
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
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
        Color color = _meshRenderer.material.color;
        Debug.Log(dist);
        Debug.Log(color.a);
        if (dist > destroyDist)
        {
            float alpha = Mathf.Min(_meshRenderer.material.color.a, dist / destroyDist);
            color.a = alpha;
            _meshRenderer.material.color = color;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
