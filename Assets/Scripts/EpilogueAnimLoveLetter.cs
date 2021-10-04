using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilogueAnimLoveLetter : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private AudioClip _endingClip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _endAnim;
    [SerializeField] private GameObject _credits;
    [SerializeField] private float creditOpenTime = 1.0f;

    public void EpilogueAnimationLoveLetterObserver(string message)
    {
        if (message.Equals("EpilogueAnimationFireEnd"))
        {
            particleSystem.gameObject.SetActive(false);
        }

        if (message.Equals("EpilogueAnimationStartKiss"))
        {
            _audioSource.PlayOneShot(_endingClip);
        }

        if (message.Equals("EpilogueAnimationEnded"))
        {
            Debug.Log("Game Over & Show Credits");
            Invoke("OpenCredit", creditOpenTime);
        }
    }
    
    private void OpenCredit()
    {
        _endAnim.SetActive(false);
        _credits.SetActive(true);
    }
}
