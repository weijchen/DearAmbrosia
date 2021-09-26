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
    [SerializeField] private GameObject prize;

    private List<Ball> newPlayer = new List<Ball>();
    private bool isATouch = false;
    private bool isBTouch = false;
    private bool runMerge = false;
    private bool hasMerged = false;
    private List<Ball> ballsToDestroy = new List<Ball>();

    private GameManager _gameManager;

    private void Start()
    {
        prize.SetActive(false);
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
            if (!hasMerged)
            {
                Ball mergedBall = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
                hasMerged = true;
                newPlayer.Add(mergedBall);
                _gameManager.SetBall(newPlayer);
                prize.SetActive(true);

                foreach (Ball ball in ballsToDestroy)
                {
                    ball.gameObject.SetActive(false);
                    Destroy(ball);
                }
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

    public void SetAMat(Material mat)
    {
        mergeA.GetComponent<MeshRenderer>().material = mat;
    }
    
    public void SetBMat(Material mat)
    {
        mergeB.GetComponent<MeshRenderer>().material = mat;
    }

    public void SetBallToDestroy(List<Ball> balls)
    {
        ballsToDestroy = balls;
        Debug.Log(ballsToDestroy.Count);
    }
}
