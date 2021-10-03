using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Serialization;

public class PrologueObject : MonoBehaviour
{
    [SerializeField] private GameObject _startAnim;
    [SerializeField] private GameObject _playBoard;
    [SerializeField] private GameObject _player;
    [SerializeField] private AudioClip _bgm;
    [SerializeField] private AudioSource _audioSource;

    void Start()
    {
        _playBoard.SetActive(false);
        _player.SetActive(false);
    }

    public void PrologueAnimationObserver(string message)
    {
        if (message.Equals("PrologueAnimationEnded"))
        {
            _startAnim.SetActive(false);
            _playBoard.SetActive(true);
            _player.SetActive(true);
            _audioSource.PlayOneShot(_bgm);
        }
    }
}
