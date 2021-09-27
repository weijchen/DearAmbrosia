using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LoveLetter")
        {
            Debug.Log(100);
        }
        else if (other.gameObject.tag == "Chocolate")
        {
            Debug.Log(200);
        }
        else if (other.gameObject.tag == "Rose")
        {
            Debug.Log(300);
        }
    }
}
