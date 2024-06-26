using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        SetUpSingleton();
    }
    public void SetUpSingleton()
    {
        int numberOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if ( numberOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
