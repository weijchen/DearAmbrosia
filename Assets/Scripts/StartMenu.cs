using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Material CollidedMaterial;
    public Material OriginalMaterial;

    private bool isCollide = false;

    // Start is called before the first frame update
    void Start()
    {

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
        }
    }
    private void ChangeButtonStatus(bool isCollide)
    {
        if (isCollide)
        {
            gameObject.GetComponent<MeshRenderer>().material = CollidedMaterial;
            gameObject.transform.localScale = new Vector3(0.3f, 0.025f, 0.3f);
            SceneManager.LoadScene("Team35_Interim");
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = OriginalMaterial;
        }
    }
}
