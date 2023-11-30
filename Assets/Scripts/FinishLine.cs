using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Star star))
        {   if(star.canFinishGame == false)
            {
                star.canFinishGame = true;
                return;
            }
            
            Debug.Log(star.onPit);
            if (star.onPit == false && star.canFinishGame)
            {
                EventManager.instance.OnGameOver?.Invoke();
            }
        }
    }
}
