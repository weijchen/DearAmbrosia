using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private GameObject ItemCollection;
    // [SerializeField] private AudioSource _audioClip;
    
    //public GameObject OpenTip;
    private bool isTouched;

    void Start()
    {
        isTouched = false;
        ItemCollection.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isTouched)
            {
                isTouched = true;
                Destroy(gameObject);
                // _audioClip.Play();
                ItemCollection.SetActive(true);    
            }
        }
    }
}
