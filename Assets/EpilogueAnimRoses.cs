using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilogueAnimRoses : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    
    public void EpilogueAnimationRosesObserver(string message)
    {
        if (message.Equals("EpilogueAnimationFireEnd"))
        {
            particleSystem.gameObject.SetActive(false);
        }
    }
}
