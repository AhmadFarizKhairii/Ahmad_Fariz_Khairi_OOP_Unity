using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public int damage = 10;
    private Rigidbody2D rb;

    public IObjectPool<Bullet> objectPool;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed;
        }
    }

    public void Shoot(Vector2 direction)
    {
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            objectPool.Release(this);
        }
    }

    private void OnBecameInvisible()
    {
        if (objectPool != null)
        {
            objectPool.Release(this);
        }
    }
}