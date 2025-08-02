using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Rigidbody2D _rb;
    float _moveSpeed = 3f;
    Vector2 direction;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] GameObject deathVFX;
    GameManager gameManager;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();  
        InvokeRepeating(nameof(EnemyShoot), 1.5f, 3f);
        gameManager = FindObjectOfType<GameManager>();
    }
    void FixedUpdate()
    {
        MoveEnemy();
        if(gameManager._GameOver == true)
        {
            CancelInvoke();
        }
    }
    public void MoveEnemy()
    {
        if (target != null)
        {
            direction = (target.position - transform.position).normalized;
            _rb.velocity = direction * _moveSpeed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        }
        else
        {
            _rb.velocity = Vector3.zero;
        }
    }
    void EnemyShoot()
    {
        Instantiate(enemyLaser, spawnPoint.position, spawnPoint.rotation);  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            EnemyExplosion();
            AudioSource.PlayClipAtPoint(deathSFX, transform.position, 500f);
            gameManager.AddScore(10);
        }
    }

    public void EnemyExplosion()
    {
       GameObject vfx = Instantiate(deathVFX, transform.position, transform.rotation);

        Destroy(vfx, 0.5f);
    }
}
