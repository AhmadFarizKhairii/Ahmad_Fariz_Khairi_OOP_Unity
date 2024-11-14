using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level = 1;
    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;  // Enemies are not affected by gravity
    }

    public virtual void TakeDamage(int damage)
    {
        // Subtract health or handle other damage logic here
        // (e.g., reduce health, check for destruction)
    }
}
