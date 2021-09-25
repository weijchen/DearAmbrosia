using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject TiltBoard;
    [SerializeField] private GameObject Ball;
    [SerializeField] private float scaleMultiplier = 0.1f;
    
    void Start()
    {
        
    }

    void Update()
    {
        AdjustBallScale();
    }

    private void AdjustBallScale()
    {
        float refScaleX = TiltBoard.transform.localScale.x * scaleMultiplier;
        float refScaleY = TiltBoard.transform.localScale.y * scaleMultiplier;
        float refScaleZ = TiltBoard.transform.localScale.z * scaleMultiplier;

        Ball.transform.localScale = new Vector3(refScaleX, refScaleY, refScaleZ);
    }
}
