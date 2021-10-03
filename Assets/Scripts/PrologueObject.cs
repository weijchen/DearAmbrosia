using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Serialization;

public class PrologueObject : MonoBehaviour
{
    [SerializeField] private GameObject playBoard;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip bgm;
    [SerializeField] private AudioSource _audioSource;

    void Start()
    {
        playBoard.SetActive(false);
        player.SetActive(false);
    }

    public void PrologueAnimationObserver(string message)
    {
        if (message.Equals("PrologueAnimationEnded"))
        {
            playBoard.SetActive(true);
            player.SetActive(true);
            _audioSource.PlayOneShot(bgm);
        }
    }
}
