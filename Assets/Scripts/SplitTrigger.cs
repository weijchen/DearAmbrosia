using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SplitTrigger : MonoBehaviour
{
    [SerializeField] private Ball playerPrefab;
    [SerializeField] private int splitToNumber;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float splitMinus = 0.01f;

    private bool hasCollide = false;
    private List<Ball> newPlayers = new List<Ball>();
    
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            if (!hasCollide)
            {
                SplitPlayer();
                Destroy(other.gameObject);
            }
        }
    }

    private void SplitPlayer()
    {
        for (int i = 0; i < splitToNumber; i++)
        {
            Ball smallPlayer = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
            smallPlayer.transform.localScale = new Vector3(playerPrefab.transform.localScale.x - splitMinus, playerPrefab.transform.localScale.y - splitMinus, playerPrefab.transform.localScale.z - splitMinus);
            newPlayers.Add(smallPlayer);
        }
        hasCollide = true;
        _gameManager.SetBall(newPlayers);
    }
}
