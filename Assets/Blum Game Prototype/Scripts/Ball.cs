using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball: MonoBehaviour
{
    [SerializeField] public BallSO _ballSO;
    [SerializeField] public Rigidbody2D _rb;
    [SerializeField] public ParticleSystem explosionVFX;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(GameManagerTest.instance.isGameFrozen)
        {
            _rb.velocity = Vector2.zero;
            return;
        }
        _rb.velocity = new Vector2(0f, UnityEngine.Random.Range(-2f, -4f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            DestroyBall();
        }
    }
    public void DestroyBall()
    {
        Destroy(gameObject);
    }
    public virtual void UseSpecialSkills()
    {

    }

}