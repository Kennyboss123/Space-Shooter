using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverScoreText;
    [SerializeField] Button tryAgainBtn;
    [SerializeField] Button mainMenuBtn;
    void Start()
    {
        gameOverScoreText.text = GameManagerTest.instance.score.ToString();
        RegisterButtons();
    }
    void RegisterButtons()
    {
       tryAgainBtn.onClick.AddListener(() => { GameManagerTest.instance.LoadGameScene(); });
        mainMenuBtn.onClick.AddListener(() => { GameManagerTest.instance.LoadStartGameScene(); });
    }
}
