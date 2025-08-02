using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    void Awake()
    {
        SetUpSingleton();
    }
    public void SetUpSingleton()
    {
        int numberOfMusicPlayers = FindObjectsOfType<AudioSystem>().Length;
        if (numberOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
