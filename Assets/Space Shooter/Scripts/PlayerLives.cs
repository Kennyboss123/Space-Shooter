using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] TMP_Text playerLives;
    private void Update()
    {
        UpdatePlayerLives();
    }
    private void UpdatePlayerLives()
    {
        playerLives.text = "Lives: " + FindObjectOfType<GameManager>().DecreasePlayerLives();
    }
}
