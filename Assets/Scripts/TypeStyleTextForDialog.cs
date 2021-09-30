using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeStyleTextForDialog : MonoBehaviour
{
    [Header("Display Text")]
    [SerializeField] string[] fullTexts;
    [SerializeField] private GameObject textDisplay;

    [Header("Text Delay Settings")]
    [SerializeField] float wordDelay = 0.1f;
    [SerializeField] private float startDelay = 0.2f;
    [SerializeField] private float midDelay = 1.0f;
    
    [Header("Dialog")]
    [SerializeField] private GameObject dialogObject;
    [SerializeField] private float dialogDeleteAfterSecond = 2.0f;

    private string currentText = "";
    private bool isPlaying = false;
    private bool hasPlayed = false;

    private void Start()
    {
        InitiateTextDisplay();
        StartCoroutine(ShowText());
    }

    private void Update()
    {
        if (hasPlayed)
        {
            if (dialogObject != null)
            {
                Destroy(dialogObject, dialogDeleteAfterSecond);
            }
        }
    }

    private void InitiateTextDisplay()
    {
        textDisplay.GetComponent<TMP_Text>().text = "";
    }

    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(startDelay);
        isPlaying = true;
        for (int i = 0; i < fullTexts.Length; i++)
        {
            for (int j = 0; j <= fullTexts[i].Length; j++)
            {
                currentText = fullTexts[i].Substring(0, j);
                textDisplay.GetComponent<TMP_Text>().text = currentText;
                yield return new WaitForSeconds(wordDelay);
            }

            if (i == 0)
            {
                yield return new WaitForSeconds(midDelay);
            }
        }
        isPlaying = false;
        hasPlayed = true;
    }
}
