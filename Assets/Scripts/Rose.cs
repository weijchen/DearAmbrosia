using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour
{
    [SerializeField] private MultiItemController _multiItemController;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioClip princePickClip;

    private SoundEffectManager _soundEffectManager;
    private static bool hasPrincePickClipPlay = false;

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
            if (!hasPrincePickClipPlay)
            {
                _soundEffectManager.PlayAudioClip(princePickClip);
                hasPrincePickClipPlay = true;
            }
            Destroy(gameObject);
        }
    }
}
