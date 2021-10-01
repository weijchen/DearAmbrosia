using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallToDestroy : MonoBehaviour
{
    [SerializeField] private GameObject heartArrow;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioClip princessSoLongClip;

    private GameManager _gameManager;
    private SoundEffectManager _soundEffectManager;

    // Start is called before the first frame update
    void Start()
    {
        _soundEffectManager = FindObjectOfType<SoundEffectManager>();
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
            _soundEffectManager.PlayAudioClip(_audioClip);
            _soundEffectManager.PlayAudioClip(princessSoLongClip);
            gameObject.SetActive(false);
            heartArrow.SetActive(true);
        }
    }
}
