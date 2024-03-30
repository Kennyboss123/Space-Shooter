using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] GameObject laser;
    [SerializeField] Transform laserSpawnPoint;
    [SerializeField] Transform laserHolder;
    [SerializeField] EnemySpawn enemyController;
    [SerializeField] AudioClip audioClip;
    float _rotateSpeed = 200f;
    float _moveSpeed = 5f;
    int playerHealth = 500;
    [SerializeField] TMP_Text healthText;
    GameManager _gameManager;
    LevelLoader _levelLoader;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _gameManager = GetComponent<GameManager>();
        _levelLoader = GetComponent<LevelLoader>();
        UpdateHealth();
    }
    void Update()
    {
        MovePlayer();
        SpawnBullet();
    }

    private void MovePlayer()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector2(0, _moveSpeed) * Time.deltaTime, Space.Self);
        }
        if(Input.GetKey(KeyCode.A)) 
        {
            transform.Rotate(new Vector3(0, 0, _rotateSpeed) * Time.deltaTime, Space.Self);
        }        
        if(Input.GetKey(KeyCode.D)) 
        {
            transform.Rotate(new Vector3(0, 0, -_rotateSpeed) * Time.deltaTime, Space.Self);
        }
        ClampedPosition();
    }
    public void ClampedPosition()
    {
        Vector3 newClampedPosition = transform.position;

        newClampedPosition.x = Mathf.Clamp(newClampedPosition.x, -8.2f, 8.2f);
        newClampedPosition.y = Mathf.Clamp(newClampedPosition.y, -4.5f, 4.5f);

        transform.position = newClampedPosition;
    }
    void SpawnBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Fire());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        GameObject Laser = Instantiate(laser, laserSpawnPoint.position, laserSpawnPoint.rotation, laserHolder);
        Laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,laserSpawnPoint.position.y * _moveSpeed);
        AudioSource.PlayClipAtPoint(audioClip, transform.position, 500f);
        yield return new WaitForSeconds(.1f);
        Destroy(Laser, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            playerHealth -= 100;
            if(playerHealth == 0)
            {
                RemoveOneLife();
            }
        }
        if(collision.gameObject.tag == "EnemyBullet")
        {
            playerHealth -= 50;
            if(playerHealth <= 0)
            {
                RemoveOneLife();
                playerHealth = 500;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Gift")
        {
            playerHealth += 100;
            Destroy(collision.gameObject);
        }
        ClampPlayerHealth();
        UpdateHealth();
    }
    void RemoveOneLife()
    {
        GameManager.instance.playerLives--;
        FindObjectOfType<SpaceBackground>().ChangeColor();
    }

    void UpdateHealth()
    {
        healthText.text = "Health: " + playerHealth.ToString();
    }
    void ClampPlayerHealth()
    {
        int minHealth = 0;
        int maxHealth = 500;
        playerHealth = Mathf.Clamp(playerHealth, minHealth, maxHealth);
    }
}
