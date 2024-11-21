using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [Header("Invincibility Settings")]
    [SerializeField] private int blinkingCount = 7; // Jumlah kedipan
    [SerializeField] private float blinkInterval = 0.1f; // Waktu antar kedipan
    [SerializeField] private Material blinkMaterial; // Material efek blinking
    private Material originalMaterial;

    private SpriteRenderer spriteRenderer;
    private HitboxComponent hitbox;
    private bool isInvincible = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<HitboxComponent>();

        // Simpan material asli untuk menggantikan kembali setelah blinking
        originalMaterial = spriteRenderer.material;
    }

    /// <summary>
    /// Mengaktifkan mode invincible dengan efek blinking.
    /// </summary>
    public void ActivateInvincibility()
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityRoutine());
        }
    }

    private IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;

        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = blinkMaterial; // Ubah ke material blinking
            yield return new WaitForSeconds(blinkInterval); // Tunggu
            spriteRenderer.material = originalMaterial; // Kembali ke material asli
            yield return new WaitForSeconds(blinkInterval); // Tunggu
        }

        isInvincible = false;
    }

    /// <summary>
    /// Mengecek apakah objek sedang dalam mode invincible.
    /// </summary>
    public bool IsInvincible()
    {
        return isInvincible;
    }
}