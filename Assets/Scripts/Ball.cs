using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : SafeZone
{
    //private SafeZone safeZone;
    [SerializeField] private Transform startPosition;
    // Start is called before the first frame update
    void Start()
    {
        //safeZone = FindObjectOfType<SafeZone>();
        Invoke("SetStartPosition", 3f);
    }

    void SetStartPosition()
    {
        SetRespawnPosition(startPosition);
    }
}
