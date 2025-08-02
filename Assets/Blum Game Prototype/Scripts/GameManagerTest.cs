using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTest : MonoBehaviour
{
    public static GameManagerTest instance;
    public int score = 0;
    public bool isPowerActive = false;
    public bool isGameFrozen = false;
    public float frozenCountdown = 5f;
    public float hyperCountDown = 5f;
    public int multiplier = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(instance);
        }
    }
    private void OnEnable()
    {
        if(GameEvents.instance != null)
        {
            GameEvents.instance.OnScoreChanged += HandleScoreUpdate;
        }
    }

    private void Update()
    {
        CheckTimer();
        FreezeGame();
    }
    public void CheckTimer()
    {
        if (!isPowerActive) return;

        hyperCountDown -= Time.deltaTime; 
        if (hyperCountDown <= 0)
        {
            isPowerActive = false;
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void HandleScoreUpdate(int scoreAmount)
    {
        int value = scoreAmount;
        if (isPowerActive && value > 0)
        {
            value *= multiplier;
        }
        score += value;
        ClampScore();
    }

    public void FreezeGame()
    {
        if (!isGameFrozen) return;
        frozenCountdown -= Time.deltaTime;

        if(frozenCountdown <= 0)
        {
            isGameFrozen = false;
        }
    }
    public void ClampScore()
    {
        int clampedScore = score;
        clampedScore = Mathf.Clamp(clampedScore, 0, 100000);
        score = clampedScore;
    }
    public void LoadStartGameScene()
    {
        SceneManager.LoadScene("StartGame");
        score = 0;
    }
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
        score = 0;
    }
 





    public void QuitGame()
    {
        Application.Quit();
    }
    private void OnDisable()
    {
        GameEvents.instance.OnScoreChanged -= HandleScoreUpdate;
    }
}
