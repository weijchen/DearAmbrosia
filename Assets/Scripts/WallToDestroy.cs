using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallToDestroy : MonoBehaviour
{
    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _gameManager = FindObjectOfType<GameManager> ();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_gameManager.keyGot == true)
        {
            gameObject.SetActive(false);
        }
    }
}
