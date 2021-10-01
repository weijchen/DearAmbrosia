using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilogueAnimLoveLetter : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    
    public void EpilogueAnimationLoveLetterObserver(string message)
    {
        if (message.Equals("EpilogueAnimationFireEnd"))
        {
            particleSystem.gameObject.SetActive(false);
        }
    }
}
