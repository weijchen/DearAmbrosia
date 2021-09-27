using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeStyleText : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";

    bool isPlaying = false;

    private void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        isPlaying = true;
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            gameObject.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        isPlaying = false;
    }

    public void SetFullText(string newText)
    {
        fullText = newText;
        StartCoroutine(ShowText());
    }

    public bool GetIsPlaying()
    {
        return isPlaying;
    }
}
