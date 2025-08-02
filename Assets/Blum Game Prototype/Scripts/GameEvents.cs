using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    
    public Action<bool> IsGameEnded;
    public Action<int> OnScoreChanged;
    public Action<bool> OnFreezeGame;
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
}
