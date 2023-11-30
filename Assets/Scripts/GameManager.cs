using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   public List<GameObject> starPrefabs;
    public List<Vector3> mergeTransforms;
    public List<int> mergeTypes;

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
    private void Start()
    {
        StartCoroutine(SpawnMergedStars());
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    IEnumerator SpawnMergedStars()
    {
        while(true)
        {
            if(mergeTypes.Count >= 1 && mergeTransforms.Count >= 1)
            {
                Instantiate(starPrefabs[mergeTypes[0]], mergeTransforms[0],Quaternion.identity);
                mergeTypes.RemoveAt(0);
                mergeTransforms.RemoveAt(0);
            }
            yield return new WaitForSeconds(0.2f);

        }
    }
   
}
