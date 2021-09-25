using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public Material CollidedMaterial;
    public Material OriginalMaterial;
    public GameObject Item1Box;
    public GameObject Item1;

    private bool isCollide = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Item1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCollide = true;
            Debug.Log(isCollide);
            ChangeButtonStatus(isCollide);
            Item1Box.SetActive(false);
            Item1.SetActive(true);
        }
    }
    private void ChangeButtonStatus(bool isCollide)
    {
        if (isCollide)
        {
            gameObject.GetComponent<MeshRenderer>().material = CollidedMaterial;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = OriginalMaterial;
        }
    }
}
