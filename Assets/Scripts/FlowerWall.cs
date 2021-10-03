using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class FlowerWall : MonoBehaviour
{
    [SerializeField] private FlowerInstance[] flowerObject;
    
    void Start()
    {
        GetAllFlowers();
        NullAllFlower();
    }

    private void GetAllFlowers()
    {
        flowerObject = GetComponentsInChildren<FlowerInstance>();
    }

    private void NullAllFlower()
    {
        foreach (FlowerInstance flower in flowerObject)
        {
            flower.transform.localScale = Vector3.zero;
        }
    }

    public void ScaleUpFlower()
    {
        foreach (FlowerInstance flower in flowerObject)
        {
            flower.StartScaleCoroutine();
        }
    }
}
