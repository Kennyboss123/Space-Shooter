using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyPrefabHolder;
    [SerializeField] Transform player;
    [SerializeField] Transform[] waypoints;
    int enemiesSpawned = 0;
    float currentSpawnRate;
    float initialSpawnRate = 4;
    GameManager _gameManager;
    void Start()
    {
        currentSpawnRate = initialSpawnRate;
        _gameManager = GetComponent<GameManager>();
        InvokeRepeating(nameof(SpawnEnemy), 2f, currentSpawnRate);
    }
    private void Update()
    {
        var test = FindObjectOfType<GameManager>();
        if(test._GameOver == true)
        {
            CancelInvoke();
        }
    }
    private Vector2 EnemyWaves()
    {
        int rand = Random.Range(0, waypoints.Length);
        return waypoints[rand].position;
    }

    void SpawnEnemy()
    {

        int randomPath = Random.Range(0, waypoints.Length);
        Transform selected = waypoints[randomPath];
        // for the position i can also call the function EnemyWaves() there.. using selected.position is more convenient for me.
        GameObject Enemy = Instantiate(enemyPrefab, selected.position, Quaternion.identity);
        EnemyController movement = Enemy.GetComponent<EnemyController>();
        movement.target = player; 
        enemiesSpawned++;
        if(enemiesSpawned % 5 == 0)
        {
            currentSpawnRate *= 0.9f;
            CancelInvoke(nameof(SpawnEnemy));
            InvokeRepeating(nameof(SpawnEnemy), 0f, currentSpawnRate);
        }
    }
}
