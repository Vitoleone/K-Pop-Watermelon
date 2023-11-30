using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MergeCheck : MonoBehaviour
{
    [SerializeField] float mergeDelay;
    Star starComponent;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Star star))
        {
            StartCoroutine(DelayedMerge(star, mergeDelay));
        }
    }
    private void Start()
    {
        starComponent = GetComponent<Star>();
    }
    IEnumerator DelayedMerge(Star star,float mergeDelay)
    {
        yield return new WaitForSeconds(mergeDelay);
        if (star.type == starComponent.type && star.transform.position.y > starComponent.transform.position.y && !starComponent.isMerging)
        {
            star.isMerging = true;
            starComponent.isMerging = true;
            
            if (starComponent.type != Star.StarType.XXL)
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
