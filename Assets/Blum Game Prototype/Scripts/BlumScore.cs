using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlumScore : MonoBehaviour
{
    public int blumPoint = 0;
    public float blumTimer = 10f;
    [SerializeField] public TextMeshProUGUI score;
    [SerializeField] public TextMeshProUGUI timer;
    void Update()
    {
        UpdateScore();
        SetTimer();
    }

    void UpdateScore()
    {
        score.text = GameManagerTest.instance.GetScore().ToString();
        ClampScore();
    }

    void SetTimer()
    {
        timer.text = blumTimer.ToString("F0");

        if (!GameManagerTest.instance.isGameFrozen)
        {
            blumTimer -= Time.deltaTime; 
        }

        if(blumTimer <= 0)
        {
            GameEvents.instance.IsGameEnded?.Invoke(true);
        }
    }

    void ClampScore()
    {
        int scoreClamp = blumPoint;
        scoreClamp = Mathf.Clamp(scoreClamp, 0, 1000);
        blumPoint = scoreClamp;

        float timerClamp = blumTimer;
        timerClamp = Mathf.Clamp(timerClamp, 0, 100);
        blumTimer = timerClamp;
    }
}
