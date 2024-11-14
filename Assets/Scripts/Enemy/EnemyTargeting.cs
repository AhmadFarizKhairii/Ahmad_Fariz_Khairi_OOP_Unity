using UnityEngine;

public class EnemyTargeting : Enemy
{
    private Transform player;
    private float speed = 50f; // Set your desired speed

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player")?.transform;  // Ensure player has a "Player" tag
    }

    private void Update()
    {
        if (player != null)
        {
            // Move toward the player
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
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
