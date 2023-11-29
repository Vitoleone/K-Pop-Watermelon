using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour
{
    [SerializeField]GameObject starObject;
    [SerializeField] float delay;
    
    private void Start()
    {
        EventManager.instance.OnSpawnStar += () => StartCoroutine(SpawnDelay(delay));
    }
    private void OnDestroy()
    {
        EventManager.instance.OnSpawnStar -= () => StartCoroutine(SpawnDelay(delay));
    }
    
    void Spawn(float delayRate)
    {
        StartCoroutine(SpawnDelay(delayRate));
    }
    IEnumerator SpawnDelay(float spawnDelay)
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(starObject,transform);
    }

    
}
