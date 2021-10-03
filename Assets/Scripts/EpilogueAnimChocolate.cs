using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilogueAnimChocolate : MonoBehaviour
{
    [SerializeField] private AudioClip _endingClip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _endAnim;
    [SerializeField] private GameObject _credits;

    public void EpilogueAnimationChocolateObserver(string message)
    {
        if (message.Equals("PrincessHitPrince"))
        {
            _audioSource.PlayOneShot(_endingClip);
        }

        if (message.Equals("EpilogueAnimationEnded"))
        {
            Debug.Log("Game Over & Show Credits");
            _endAnim.SetActive(false);
            _credits.SetActive(true);
        }
    }
}
