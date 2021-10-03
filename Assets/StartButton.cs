using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [Header("Start Animation Settings")]
    [SerializeField] private AudioClip augueClip;
    [SerializeField] private float animPlaySpeed = 0.3f;
    [SerializeField] private GameObject prologueGameObj;
    
    [SerializeField] private TypeStyleTextForDialog[] _dialogs;
    [SerializeField] Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private bool proAnimFinished = false;
    
    void Start()
    {
        prologueGameObj.SetActive(false);
    }

    public void PlayAnimation()
    {
        foreach (TypeStyleTextForDialog dialog in _dialogs)
        {
            dialog.StartTextDialog();
        }
        prologueGameObj.SetActive(true);
        _animator.speed = animPlaySpeed;
        _animator.SetTrigger("StartAnim");
        _audioSource.PlayOneShot(augueClip);
        Destroy(gameObject);
    }
}
