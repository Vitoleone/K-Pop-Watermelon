using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeCheck : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Star star))
        {
            if(star.type == GetComponent<Star>().type)
            {
                star.Merge();
            }
        }
    }
}
