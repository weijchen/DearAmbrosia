using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSimp : MonoBehaviour
{
    [SerializeField] private GameObject TiltBoard;
    [SerializeField] private List<Ball> balls;
    [SerializeField] private float scaleMultiplier = 0.1f;
    
    void Update()
    {
        AdjustBallScale();
    }

    private void AdjustBallScale()
    {
        float refScaleX = TiltBoard.transform.localScale.x * scaleMultiplier;
        float refScaleY = TiltBoard.transform.localScale.y * scaleMultiplier;
        float refScaleZ = TiltBoard.transform.localScale.z * scaleMultiplier;

        Debug.Log("Number of ball: " + balls.Count);
        foreach (var ball in balls)
        {
            ball.transform.localScale = new Vector3(refScaleX, refScaleY, refScaleZ);
        }
    }
}
