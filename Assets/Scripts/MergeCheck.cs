using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeCheck : MonoBehaviour
{
    [SerializeField] float mergeDelay;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Star star))
        {
            StartCoroutine(DelayedMerge(star, mergeDelay));
        }
    }
    IEnumerator DelayedMerge(Star star,float mergeDelay)
    {
        yield return new WaitForSeconds(mergeDelay);
        if (star.type == GetComponent<Star>().type && star.transform.position.y > GetComponent<Star>().transform.position.y)
        {
            
            if (GetComponent<Star>().type != Star.StarType.XXL)
            {
                if(!GameManager.instance.mergeTransforms.Contains(transform.position))
                {
                    Debug.Log(transform.position);
                    GameManager.instance.mergeTransforms.Add(transform.position);
                    GameManager.instance.mergeTypes.Add((int)star.type);
                }
            }
            Destroy(star.gameObject);
            Destroy(gameObject);
        }
    }
}
