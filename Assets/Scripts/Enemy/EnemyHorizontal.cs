using UnityEngine;

public class EnemyHorizontal : Enemy
{
    private Vector2 direction;
    private float speed = 2f; // Set your desired speed

    protected override void Start()
    {
        base.Start();
        // Tentukan arah spawn: bergerak ke kiri jika muncul di sisi kanan, dan sebaliknya
        direction = transform.position.x > 0 ? Vector2.left : Vector2.right;
    }

    private void Update()
    {
        // Gerakkan musuh
        transform.Translate(direction * speed * Time.deltaTime);

        // Balikkan arah saat musuh melewati batas layar
        if (transform.position.x < -10 || transform.position.x > 10) // Sesuaikan batas layar sesuai kebutuhan
        {
            // Ubah arah pergerakan
            direction = -direction;

            // Reset posisi ke dalam layar
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        // Reset posisi musuh ke dalam layar
        if (transform.position.x < -10)
        {
            transform.position = new Vector2(-9.5f, transform.position.y); // Pindahkan sedikit ke dalam layar dari kiri
        }
        else if (transform.position.x > 10)
        {
            transform.position = new Vector2(9.5f, transform.position.y); // Pindahkan sedikit ke dalam layar dari kanan
        }
    }
}