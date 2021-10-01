using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject TiltBoard;
    [SerializeField] private List<Ball> balls;
    [SerializeField] private float scaleMultiplier = 0.1f;
    [SerializeField] private GameObject key;
    [SerializeField] private Material[] _materials;
    [SerializeField] private GameObject boardBase;
    [SerializeField] private AudioClip loveLetterSceneClip;
    [SerializeField] private AudioClip chocolateSceneClip;
    [SerializeField] private AudioClip roseSceneClip;
    [SerializeField] private AudioSource bgmManager;
    [SerializeField] private float audioFadeInTime = 0.2f;
    [SerializeField] private float audioFadeOutTime = 0.2f;
    [SerializeField] private GameObject mainItem;
    [SerializeField] private Ball prince;
    [SerializeField] private ConnectFlower[] rightMazeWall;

    [Header("Love Letter Text")] 
    [SerializeField] private TypeStyleTextForDialog _loveLetterTextPrince;
    [SerializeField] private TypeStyleTextForDialog _loveLetterTextPrincess;
    [SerializeField] private FlowerWall leftFlowerWall;
    
    private int giftCollected = 0;
    private int targetGiftToCollect = 3;
    private int endingSelection = 0;

    public bool keyGot;
    public bool keyVisible;
    private AudioSource audioManager;

        
    private void Start()
    {
        keyGot = false;
        keyVisible = false;
        key.SetActive(false);
        audioManager = GetComponent<AudioSource>();
    }
    void Update()
    {
        AdjustBallScale();
        ChangeBoardColor();
        if (giftCollected == targetGiftToCollect)
        {
            CollectAllGift();
        }
    }

    private void AdjustBallScale()
    {
        float refScaleX = TiltBoard.transform.localScale.x * scaleMultiplier;
        float refScaleY = TiltBoard.transform.localScale.y * scaleMultiplier;
        float refScaleZ = TiltBoard.transform.localScale.z * scaleMultiplier;

        foreach (var ball in balls)
        {
            ball.transform.localScale = new Vector3(refScaleX, refScaleY, refScaleZ);
        }
    }

    public void SetBall(List<Ball> newBalls)
    {
        balls = newBalls;
    }

    private void CollectAllGift()
    {
        key.SetActive(true);
        targetGiftToCollect = 0;
    }

    public void AddGiftCollected()
    {
        giftCollected += 1;
        if (giftCollected == targetGiftToCollect)
        {
            Debug.Log("collect all!");
            leftFlowerWall.ScaleUpFlower();
            
            foreach (ConnectFlower wall in rightMazeWall)
            {
                wall.SetGiftsAreCollected(true);
            }

        }
    }

    public void ChangeBoardColor()
    {
        boardBase.GetComponent<MeshRenderer>().material = _materials[giftCollected];
    }

    public void ShowEndingAnim(int selection)
    {
        if (selection == 0)
        {
            StartCoroutine(AudioFadeScript.FadeOut(bgmManager, audioFadeOutTime));
            audioManager.clip = loveLetterSceneClip;
            mainItem.SetActive(false);
            prince.gameObject.SetActive(false);
            _loveLetterTextPrince.StartTextDialog();
            _loveLetterTextPrincess.StartTextDialog();
            StartCoroutine(AudioFadeScript.FadeIn(audioManager, audioFadeInTime));
        } else if (selection == 1)
        {
            StartCoroutine(AudioFadeScript.FadeOut(bgmManager, audioFadeOutTime));
            audioManager.clip = loveLetterSceneClip;
            StartCoroutine(AudioFadeScript.FadeIn(audioManager, audioFadeInTime));
        }
        else
        {
            StartCoroutine(AudioFadeScript.FadeOut(bgmManager, audioFadeOutTime));
            audioManager.clip = loveLetterSceneClip;
            StartCoroutine(AudioFadeScript.FadeIn(audioManager, audioFadeInTime));
        }
    }
}

public static class AudioFadeScript
{
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.Stop();
        audioSource.volume = startVolume;
    }
 
    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.2f;
 
        audioSource.volume = 0;
        audioSource.Play();
 
        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.volume = 1f;
    }
}
