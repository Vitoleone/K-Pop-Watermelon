using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
    [SerializeField] public List<GameObject> starObjects;
    [SerializeField] public List<GameObject> spawnedObject;

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
    public int score;
    public int ballID = 0;

    public void AddScore(int amount)
    {
        score += amount;
    }
    public int GetCurrentBallId()
    {
        return ballID++; 
    }
}
