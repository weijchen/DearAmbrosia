using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public Material CollidedMaterial;
    public Material OriginalMaterial;
    public GameObject Item1Box;
    public GameObject LoveLetter;

    private bool isCollide = false;
    
    // Start is called before the first frame update
    void Start()
    {
        LoveLetter.SetActive(false);
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
            LoveLetter.SetActive(true);
        }
    }
    private void ChangeButtonStatus(bool isCollide)
    {
        if (isCollide)
        {
            gameObject.GetComponent<MeshRenderer>().material = CollidedMaterial;
            gameObject.transform.localScale = new Vector3(0.01f, 0.0005f, 0.01f);
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = OriginalMaterial;
        }
    }
}
