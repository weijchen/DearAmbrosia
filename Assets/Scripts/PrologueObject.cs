using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueObject : MonoBehaviour
{
    [SerializeField] private GameObject playBoard;
    [SerializeField] private GameObject player;
    [SerializeField] private float OpenPlayObjectsAfterTime = 3.0f;
    [SerializeField] private AudioClip augueClip;

    private AudioSource _audioSource;

    private bool proAnimFinished = false;
    
    void Start()
    {
        playBoard.SetActive(false);
        player.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(augueClip);
    }

    public void PrologueAnimationObserver(string message)
    {
        if (message.Equals("PrologueAnimationEnded"))
        {
            proAnimFinished = true;
            playBoard.SetActive(true);
            player.SetActive(true);
        }
    }
}
