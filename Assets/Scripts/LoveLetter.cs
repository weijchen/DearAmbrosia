using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLetter : MonoBehaviour
{
    public GameObject OpenedLetter;

    //[SerializeField] private AudioSource _audioClip;
    //public GameObject OpenTip;
    private bool isTouched;
    
    // Start is called before the first frame update
    void Start()
    {
        isTouched = false;
        OpenedLetter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTouched = true;
            OpenedLetter.SetActive(true);
        }
    }
}
