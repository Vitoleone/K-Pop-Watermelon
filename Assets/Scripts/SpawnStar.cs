using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        int random = Random.Range(0, (int)(GameManager.instance.starPrefabs.Count/2));
        Star newStar= Instantiate(GameManager.instance.starPrefabs[random],transform.position,Quaternion.identity).GetComponent<Star>();
        newStar.onPit = true;
        newStar.GetComponent<Rigidbody2D>().gravityScale = 0;
        
    }

    
}
