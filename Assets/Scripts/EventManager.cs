using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Action<Star> OnStarMerged;
    public Action<Star, Rigidbody2D> OnStarReleased;
    public Action OnSpawnStar;
    public static EventManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
