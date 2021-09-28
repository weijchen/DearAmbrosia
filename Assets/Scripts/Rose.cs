using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour
{
    [SerializeField] private MultiItemController _multiItemController;
    [SerializeField] private AudioClip _audioClip;

    private SoundEffectManager _soundEffectManager;

    private void Start()
    {
        _soundEffectManager = FindObjectOfType<SoundEffectManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            _multiItemController.CollectItem();
            _soundEffectManager.PlayAudioClip(_audioClip);
            Destroy(gameObject);
        }
    }
}
