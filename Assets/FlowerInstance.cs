using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInstance : MonoBehaviour
{
    [SerializeField] private float scaleTime = 4.0f;

    private Vector3 originScale;
    
    void Start()
    {
        originScale = transform.localScale;
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
        
        while (i < 1)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(fromScale, toScale, i);
            yield return 0;
        }
    }
}

