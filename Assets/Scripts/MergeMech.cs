using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MergeMech : MonoBehaviour
{
    [SerializeField] private Ball playerPrefab;
    [SerializeField] private MergeMechComponent mergeA;
    [SerializeField] private MergeMechComponent mergeB;
    [SerializeField] private Transform respawnPoint;

    private List<Ball> newPlayer = new List<Ball>();
    private bool isATouch = false;
    private bool isBTouch = false;
    private bool runMerge = false;
    private bool hasMerged = false;
    
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (isATouch && isBTouch)
        {
            runMerge = true;
        }

        if (runMerge && !hasMerged)
        {
            Destroy(mergeA.GetTouchObject());
            Destroy(mergeB.GetTouchObject());
            if (!hasMerged)
            {
                Ball mergedBall = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
                hasMerged = true;
                newPlayer.Add(mergedBall);
                _gameManager.SetBall(newPlayer);
            }
        }
    }

    public void SetATouch(bool state)
    {
        isATouch = state;
    }

    public void SetBTouch(bool state)
    {
        isBTouch = state;
    }
}
