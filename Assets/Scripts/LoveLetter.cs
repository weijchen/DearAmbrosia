using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLetter : MonoBehaviour
{
    public GameObject OpenedLetter;
    private bool isOpened;
    
    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
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
            isOpened = true;
            ChangeLetterStatus(isOpened);
        }
    }

    private void ChangeLetterStatus(bool isOpened)
    {
        if(isOpened)
        {
            OpenedLetter.SetActive(true);
        }
        else
        {
            OpenedLetter.SetActive(false);
        }
    }
}
