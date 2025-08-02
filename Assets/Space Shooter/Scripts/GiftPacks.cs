using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftPacks : MonoBehaviour
{
    [SerializeField] GameObject giftsPrefab;
    [SerializeField] Transform[] spawnpoint;
    int currentSpawn = 0;
    GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating(nameof(Gifts), 5f, 15f);
        
    }
    private void Update()
    {
        if(_gameManager._GameOver == true)
        {
            CancelInvoke();
        }
    }
    void Gifts()
    {
        currentSpawn = Random.Range(0, spawnpoint.Length);
        GameObject gifts = Instantiate(giftsPrefab, spawnpoint[currentSpawn].position, Quaternion.identity);
        Destroy(gifts, 5f);
    }

}
