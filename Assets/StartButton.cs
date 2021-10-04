using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class StartButton : MonoBehaviour, IMixedRealityTouchHandler
{
    [Header("Start Animation Settings")]
    [SerializeField] private AudioClip augueClip;
    [SerializeField] private float animPlaySpeed = 0.3f;
    [SerializeField] private GameObject prologueGameObj;
    
    [SerializeField] private TypeStyleTextForDialog[] _dialogs;
    [SerializeField] Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private bool proAnimFinished = false;
    private BoxCollider _boxCollider;
    
    void Start()
    {
        prologueGameObj.SetActive(false);
        _boxCollider = GetComponent<BoxCollider>();
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
    
    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        GetComponent<StartButton>().enabled = true;
        GetComponent<NearInteractionTouchable>().enabled = false;
        PlayAnimation();
        _boxCollider.enabled = false;
        GetComponent<StartButton>().enabled = false;
    }
    public void OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        Debug.Log("TouchCompleted");
    }
    public void OnTouchUpdated(HandTrackingInputEventData eventData)
    {
        //Debug.Log("TouchUpdated");
    }
}
