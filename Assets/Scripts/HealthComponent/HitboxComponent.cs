using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HitboxComponent : MonoBehaviour
{
    private HealthComponent health;

    private void Start()
    {
        health = GetComponent<HealthComponent>(); // Ambil HealthComponent dari objek ini
    }

    public void Damage(int amount)
    {
        health.Subtract(amount); // Kurangi health dengan integer
    }

    public void Damage(Bullet bullet)
    {
        health.Subtract(bullet.DamageAmount); // Kurangi health dengan damage dari bullet
    }
}