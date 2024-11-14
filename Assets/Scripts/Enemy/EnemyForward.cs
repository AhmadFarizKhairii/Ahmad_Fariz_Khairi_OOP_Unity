using UnityEngine;

public class EnemyForward : Enemy
{
    private float speed = 3f; // Set your desired speed

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Destroy the enemy if it goes off the bottom of the screen
        if (transform.position.y < -10) // Adjust screen boundaries as needed
        {
            Destroy(gameObject);  // Destroy or return to object pool
        }
    }
}
