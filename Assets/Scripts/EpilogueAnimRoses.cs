using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilogueAnimRoses : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private AudioClip _endingClip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _endAnim;
    [SerializeField] private GameObject _credits;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private float creditOpenTime = 1.0f;

    public void EpilogueAnimationRosesObserver(string message)
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
            Debug.Log("End");
            _endAnim.SetActive(false);
            Invoke("OpenCredit", creditOpenTime);
        }
    }
    
    private void OpenCredit()
    {
        _credits.SetActive(true);
        _restartButton.SetActive(true);
    }
}
