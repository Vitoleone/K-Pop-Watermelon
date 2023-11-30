using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   public List<GameObject> starPrefabs;
    public List<Vector3> mergeTransforms;
    public List<int> mergeTypes;
    public GameObject mergeEffect;
    public GameObject GameOverText;
    public bool isGameOver = false;

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
        EventManager.instance.OnScoreChanged?.Invoke();
        EventManager.instance.OnGameOver += (() => StartCoroutine(GameOver()));

    }
    
    private void OnDisable()
    {
        EventManager.instance.OnGameOver -= (() => StartCoroutine(GameOver()));
    }

    public void AddScore(int amount)
    {
        score += amount;
        EventManager.instance.OnScoreChanged?.Invoke();
    }
    public IEnumerator GameOver()
    {
        isGameOver = true;
        GameOverText.gameObject.SetActive(true);
        Debug.Log("Game Over");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator SpawnMergedStars()
    {
        while(true)
        {
            if(mergeTypes.Count >= 1 && mergeTransforms.Count >= 1)
            {
                GameObject mergedStar = Instantiate(starPrefabs[mergeTypes[0]], mergeTransforms[0],Quaternion.identity);
                Instantiate(mergeEffect, mergedStar.transform);
                mergedStar.GetComponent<Star>().canFinishGame = true;
                mergeTypes.RemoveAt(0);
                mergeTransforms.RemoveAt(0);
            }
            yield return new WaitForSeconds(0.2f);

        }
    }
   
}
