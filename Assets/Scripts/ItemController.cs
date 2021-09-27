using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject ItemCollection;

    // [SerializeField] private AudioSource _audioClip;
    //public GameObject OpenTip;
    private bool isTouched;

    // Start is called before the first frame update
    void Start()
    {
        isTouched = false;
        ItemCollection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTouched = true;
            Destroy(gameObject);
            // _audioClip.Play();
            Debug.Log(100);
            ItemCollection.SetActive(true);
        }
    }
}
