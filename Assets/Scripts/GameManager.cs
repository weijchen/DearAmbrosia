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
    [SerializeField] private GameObject[] Handle;
    [SerializeField] private GameObject HandleCollider;

    [Header("Ending Animation Text")] 
    [SerializeField] private TypeStyleTextForDialog _loveLetterTextPrince;
    [SerializeField] private TypeStyleTextForDialog _loveLetterTextPrincess;
    [SerializeField] private TypeStyleTextForDialog _chocolatesTextPrince;
    [SerializeField] private TypeStyleTextForDialog _chocolatesTextPrincess;
    [SerializeField] private TypeStyleTextForDialog _rosesTextPrince;
    [SerializeField] private TypeStyleTextForDialog _rosesTextPrincess;
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
        Handle = GameObject.FindGameObjectsWithTag("Handle");
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

    public void HideHandle()
    {
        for (int i = 0; i < Handle.Length; i++)
        {
            Handle[i].GetComponent<MeshRenderer>().enabled = false;
            HandleCollider.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    public IEnumerator ShowHandle()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < Handle.Length; i++)
        {
            Handle[i].GetComponent<MeshRenderer>().enabled = true;
            HandleCollider.GetComponent<CapsuleCollider>().enabled = true;
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
            audioManager.clip = chocolateSceneClip;
            mainItem.SetActive(false);
            prince.gameObject.SetActive(false);
            _chocolatesTextPrince.StartTextDialog();
            _chocolatesTextPrincess.StartTextDialog();
            StartCoroutine(AudioFadeScript.FadeIn(audioManager, audioFadeInTime));
        }
        else
        {
            StartCoroutine(AudioFadeScript.FadeOut(bgmManager, audioFadeOutTime));
            audioManager.clip = roseSceneClip;
            mainItem.SetActive(false);
            prince.gameObject.SetActive(false);
            _rosesTextPrince.StartTextDialog();
            _rosesTextPrincess.StartTextDialog();
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
