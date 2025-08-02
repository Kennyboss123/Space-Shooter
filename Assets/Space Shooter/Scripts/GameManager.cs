using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool _GameOver = false;
    int score = 0;
    public int playerLives = 3;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            Destroy(instance);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void AddScore(int amount)
    {
        score += amount;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public int DecreasePlayerLives()
    {
        if(playerLives == 0)
        {
            FindObjectOfType<LevelLoader>().LoadGameOverScene();
        }
        return playerLives;
    }
}
