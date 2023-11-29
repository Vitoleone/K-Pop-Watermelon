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
        XXL = 6
    }
    [SerializeField] public StarType type;
    [SerializeField] public int value;
    [SerializeField] public bool onPit;
    [SerializeField] public SpriteRenderer starImage;
    [SerializeField] int ballID;
    [SerializeField] Transform SpawnLocation;
    [SerializeField] Rigidbody2D myRb;



    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        EventManager.instance.OnStarMerged += OnStarMerged;
    }
    private void OnDestroy()
    {
        EventManager.instance.OnStarMerged -= OnStarMerged;
    }

    public void Spawned()
    {
        gameObject.SetActive(true);
        AttachBallID(GameManager.instance.GetCurrentBallId());
        onPit = true;
        myRb.gravityScale = 0;
    }

    public void Merge()
    {

        EventManager.instance.OnStarMerged?.Invoke(this);
    }
    public void AttachBallID(int id)
    {
        ballID = id;
    }


    public void OnStarMerged(Star star)
    {
        GameManager.instance.AddScore(value);
        if (star.ballID < ballID)
        {
            
            gameObject.SetActive(false);
            gameObject.transform.position = SpawnLocation.position;
            GameManager.instance.starObjects.Add(gameObject);
        }
        else
        {
            if (type == StarType.XXL)
            {
                gameObject.SetActive(false);
                gameObject.transform.position = SpawnLocation.position;
                GameManager.instance.starObjects.Add(gameObject);
                return;
            }
                
            this.type += 1;
            //ChangeSprite(MergeManager.instance.starSprites[(int)type]);
        }
        
        
        
        //change sprite to larger star's sprite

        //Move the midle point between this and other star.
    }
    void ChangeSprite(Sprite sprite)
    {
        starImage.sprite = sprite;
    }
}
