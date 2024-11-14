using UnityEngine;

public class EnemyBoss : Enemy
{
    public GameObject bulletPrefab; // Assign bullet prefab in the Inspector
    public Transform bulletSpawnPoint; // Assign spawn point in the Inspector

    private float shootInterval = 0.1f; // Set the shooting interval
    private float shootTimer = 0f;

    private float speed = 1f; // Slow speed for boss movement

    private void Update()
    {
        Move();
        HandleShooting();
    }

    private void Move()
    {
        // Basic left-right movement (can adjust movement pattern as needed)
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -5 || transform.position.x > 5) // Adjust boundaries for boss
        {
            speed = -speed;
        }
    }

    private void HandleShooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Damage player or apply other effects
            Destroy(gameObject);  // Destroy or return to object pool
        }
    }
}
