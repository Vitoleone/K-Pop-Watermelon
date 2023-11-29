using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Star : MonoBehaviour
{
    
    [Serializable]
    public enum StarType
    {
        XS,
        S,
        MS,
        M,
        L,
        XL,
        XXL
    }
    [SerializeField] public StarType type;
    [SerializeField] public int value;
    [SerializeField] public bool onPit;
    [SerializeField] Sprite starImage;

    private void Start()
    {
        EventManager.instance.OnStarMerged += OnStarMerged;
    }
    private void OnDestroy()
    {
        EventManager.instance.OnStarMerged -= OnStarMerged;
    }


    public void Merge()
    {
        if (type == StarType.XXL)
            return;
        this.type += 1;
        EventManager.instance.OnStarMerged?.Invoke(this);
    }
    
    public void OnStarMerged(Star star)
    {
        //add value to score
        //
    }
}
