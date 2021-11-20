using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour, IMixedRealityTouchHandler
{
    private bool proAnimFinished = false;
    private BoxCollider _boxCollider;
    
    void Start()
    {
       
        _boxCollider = GetComponent<BoxCollider>();
    }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        GetComponent<RestartButton>().enabled = true;
        GetComponent<NearInteractionTouchable>().enabled = false;
        _boxCollider.enabled = false;
        GetComponent<RestartButton>().enabled = false;
        SceneManager.LoadScene("StartMenu");
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
