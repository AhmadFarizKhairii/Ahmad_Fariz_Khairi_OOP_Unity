using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    private void Start()
    {
        health = maxHealth; // Inisialisasi health dengan maxHealth
    }

    public int Health => health; // Getter untuk health

    public void Subtract(int amount)
    {
        health -= amount; // Kurangi health
        if (health <= 0)
        {
            Destroy(gameObject); // Hancurkan objek jika health <= 0
        }
    }
}