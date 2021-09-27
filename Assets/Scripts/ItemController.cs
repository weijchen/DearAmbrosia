using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private GameObject ItemCollection;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _CollideClip;

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
                _audioSource.PlayOneShot(_CollideClip);
                ItemCollection.SetActive(true);    
            }
        }
    }
}
