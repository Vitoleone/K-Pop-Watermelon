using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Star : MonoBehaviour
{
    
    [Serializable]
    public enum StarType
    {
        XS = 1,
        S = 2,
        M = 3,
        L = 4,
        XL = 5,
        XXL = 6,
        F = 7,
        XF = 8,
        XXF = 9,
        H = 10,

    }
    [SerializeField] public StarType type;
    [SerializeField] public int value;
    [SerializeField] public bool onPit;
    [SerializeField] Transform SpawnLocation;
    [SerializeField] Rigidbody2D myRb;
    public bool isMerging = false;
    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }
    private void OnDestroy()
    {
        GameManager.instance.AddScore(value);
    }

    public void Spawned()
    {
        gameObject.SetActive(true);
        
        onPit = true;
        myRb.gravityScale = 0;
    }

    
    
}
