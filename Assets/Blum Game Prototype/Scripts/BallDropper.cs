using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropper : MonoBehaviour
{
    [SerializeField] Transform[] ballPathway;
    [SerializeField] GameManagerTest _gameManagerTest;
    [SerializeField] ParticleSystem _particleSystem;

    [SerializeField] Ball[] _balls;    
    private void OnEnable()
    {
        GameEvents.instance.IsGameEnded += HandleGameEnded;

    }
    public void HandleGameEnded(bool value)
    {
        if (value)
        {
            _gameManagerTest.LoadGameOverScene();
        }
    }
    void Start()
    {
        _gameManagerTest = FindObjectOfType<GameManagerTest>();
        InvokeRepeating("BallsSpawn", 1f, 0.5f);
    }
    void BallsSpawn()
    {
        int randomPath = Random.Range(0, ballPathway.Length);
        Transform selectedPath = ballPathway[randomPath];

        int randomNumber = Random.Range(0, 100);
        for (int i = 0; i < _balls.Length; i++)
        {
            Ball _ball = _balls[i];
            if(IsInRange(randomNumber, _ball._ballSO.minValue, _ball._ballSO.maxValue) && GameManagerTest.instance.isGameFrozen == false)
            {
                Instantiate(_ball, selectedPath.position, Quaternion.identity);
            }
        }
    }
    bool IsInRange(float value, float min, float max)
    {
        return value >= min && value <= max;
    }
    private void OnDisable()
    {
        GameEvents.instance.IsGameEnded -= HandleGameEnded;
    }
}