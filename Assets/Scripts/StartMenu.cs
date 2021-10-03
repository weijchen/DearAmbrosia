using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Material CollidedMaterial;
    [SerializeField] private Material OriginalMaterial;

    private bool itemHasCollect = false;
    private bool isCollide = false;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = OriginalMaterial;
    }

    public void SetItemHasCollect(bool state)
    {
        itemHasCollect = true;
        gameObject.GetComponent<MeshRenderer>().material = CollidedMaterial;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && itemHasCollect)
        {
            SceneManager.LoadScene("MainScene");
            isCollide = true;
        }
    }
}
