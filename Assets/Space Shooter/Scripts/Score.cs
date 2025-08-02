using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    TMP_Text scoreText;
    GameManager gameManager;
    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        UpdateScore();
    }
    private void UpdateScore()
    {
        scoreText.text = "Score: " + gameManager.GetScore();
    }
}
