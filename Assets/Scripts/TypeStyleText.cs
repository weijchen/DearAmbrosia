using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeStyleText : MonoBehaviour
{
    [SerializeField] float delay = 0.1f;
    [SerializeField] string[] fullTexts;
    [SerializeField] private GameObject[] textDisplay;
    [SerializeField] private GameObject ItemCollection;
    [SerializeField] private float destroyAfterSeconds = 2.0f;

    private string currentText = "";
    private bool isPlaying = false;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        ItemCollection.SetActive(false);
        InitiateTextDisplay();
        StartCoroutine(ShowText());
    }

    private void InitiateTextDisplay()
    {
        foreach (var text in textDisplay)
        {
            text.GetComponent<TMP_Text>().text = "";
        }
    }

    IEnumerator ShowText()
    {
        isPlaying = true;
        for (int i = 0; i < fullTexts.Length; i++)
        {
            for (int j = 0; j <= fullTexts[i].Length; j++)
            {
                currentText = fullTexts[i].Substring(0, j);
                textDisplay[i].GetComponent<TMP_Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
        }
        ItemCollection.SetActive(true);
        isPlaying = false;
        _gameManager.AddGiftCollected();
        Destroy(gameObject.transform.parent.gameObject, destroyAfterSeconds);
    }
}
