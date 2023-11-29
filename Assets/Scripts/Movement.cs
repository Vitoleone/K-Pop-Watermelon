using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 mousePos;
    SpriteRenderer mySprite;
    Rigidbody2D myRigidbody;
    Star star;
    private void Start()
    {
        EventManager.instance.OnStarReleased += OnStarReleased;
        star = GetComponent<Star>();
        myRigidbody = GetComponent<Rigidbody2D>();
        
    }

    private void OnDisable()
    {
        EventManager.instance.OnStarReleased -= OnStarReleased;
    }

    // Update is called once per frame
    void Update()
    {
        if (star.onPit) 
        {
            if (Input.GetMouseButton(0))
            {
                gameObject.transform.position = GetMousePosition();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                EventManager.instance.OnStarReleased?.Invoke(star, myRigidbody);
                EventManager.instance.OnSpawnStar?.Invoke();
            }
        }
        
    }
    Vector3 GetMousePosition()
    {
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, gameObject.transform.position.y,1);
        mySprite = gameObject.GetComponent<SpriteRenderer>();
        if (mousePos.x + Camera.main.ScreenToWorldPoint(new Vector2(mySprite.sprite.rect.width * gameObject.transform.localScale.x, 0)).x * 0.3f <= Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x && mousePos.x - Camera.main.ScreenToWorldPoint(new Vector2(mySprite.sprite.rect.width * gameObject.transform.localScale.x, 0)).x * 0.3f >= -Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x)
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(new Vector2(mySprite.sprite.rect.width, 0)).x * 0.35f);
            return mousePos;
            
        }
        
        return gameObject.transform.position;
    }
    void OnStarReleased(Star star,Rigidbody2D myrb)
    {
        myrb.gravityScale = 1;
        star.onPit = false;
    }


     
     //if (mousePos.x <= 1.1f && mousePos.x >= -1.1f)
     //   {
     //       return mousePos;
     //   }
}
