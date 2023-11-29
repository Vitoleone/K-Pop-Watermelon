using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour
{
    
    [SerializeField] float delay;
    
    private void Start()
    {
        
        EventManager.instance.OnSpawnStar += () => StartCoroutine(SpawnDelay(delay));
        StartCoroutine(SpawnDelay(delay));
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
        int random = Random.Range(0, GameManager.instance.starObjects.Count);
        Star newStar = GameManager.instance.starObjects[random].GetComponent<Star>();
        GameManager.instance.spawnedObject.Add(newStar.gameObject);
        GameManager.instance.starObjects.Remove(newStar.gameObject);
        newStar.Spawned();

    }

    
}
