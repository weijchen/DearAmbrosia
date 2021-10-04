using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class HandTrace : MonoBehaviour, IMixedRealityTouchHandler
{
    [SerializeField] private ItemCollections _itemCollections;
    // [SerializeField] private bool showDistance;

    [SerializeField] private BoxCollider _boxCollider;

    void Update()
    {
        // var handJointService = Microsoft.MixedReality.Toolkit.CoreServices.GetInputSystemDataProvider<IMixedRealityHandJointService>();
        // if (handJointService != null)
        // {
        //     Transform jointTransform = handJointService.RequestJointTransform(TrackedHandJoint.IndexTip, Handedness.Right);
        //     float distanceWithHand = Vector3.Distance(_itemCollections.transform.position, jointTransform.position);
        //     if (showDistance)
        //     {
        //         Debug.Log(distanceWithHand);
        //     }
        //     if (distanceWithHand <= 0.1f)
        //     {
        //         _itemCollections.DetectHandClick();
        //     }
        // }   
    }
    
    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        GetComponent<HandTrace>().enabled = true;
        GetComponent<NearInteractionTouchable>().enabled = false;
        _itemCollections.DetectHandClick();
        _boxCollider.enabled = false;
        GetComponent<HandTrace>().enabled = false;
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
