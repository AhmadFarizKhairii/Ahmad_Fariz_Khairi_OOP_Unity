using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AttackComponent : MonoBehaviour
{
    public Bullet bulletPrefab; // Prefab bullet
    public int damage; // Damage yang diberikan

    private void OnTriggerEnter(Collider other)
    {
        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        if (hitbox != null)
        {
            hitbox.Damage(damage); // Kurangi health jika ada HitboxComponent
        }
    }
}