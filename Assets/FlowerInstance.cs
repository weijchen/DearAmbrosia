using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using UnityEngine;

public class FlowerInstance : MonoBehaviour
{
    [SerializeField] private float scaleTime = 4.0f;

    private Vector3 originScale;

    private void Awake()
    {
        originScale = transform.localScale;
    }

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        transform.localScale = Vector3.zero;
    }

    public void StartScaleCoroutine()
    {
        StartCoroutine(ScaleUp(scaleTime));
    }

    IEnumerator ScaleUp(float scaleTime)
    {
        float i = 0f;
        float rate = 1 / scaleTime;

        Vector3 fromScale = transform.localScale;
        Vector3 toScale = originScale;

        Debug.Log(fromScale);
        Debug.Log(toScale);
        
        while (i < 1)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(fromScale, toScale, i);
            yield return 0;
        }
    }
}

