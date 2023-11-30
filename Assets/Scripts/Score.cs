using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        EventManager.instance.OnScoreChanged += OnScoreChangedCallback;
    }
    private void OnDisable()
    {
        EventManager.instance.OnScoreChanged -= OnScoreChangedCallback;
    }

    void OnScoreChangedCallback()
    {
        scoreText.text = "Score:" + GameManager.instance.score.ToString();
    }
}
