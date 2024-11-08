using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder; // Menampung objek weapon yang bisa dipickup
    private Weapon weapon;

    void Awake()
    {
        // Membuat instance dari weaponHolder jika ada
        if (weaponHolder != null)
        {
            weapon = Instantiate(weaponHolder);
        }
    }

    void Start()
    {
        if (weapon != null)
        {
            // Menonaktifkan visual dan komponen terkait weapon pada awal permainan
            TurnVisual(false);
            weapon.transform.SetParent(transform, false);
            weapon.transform.localPosition = transform.position;
            weapon.parentTransform = transform; // Set posisi weapon ke transform pickup point
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (weapon.transform.parent == transform && other.CompareTag("Player"))
        {
            // Cek apakah player sudah memiliki weapon dan ambil weapon tersebut
            Weapon currentWeapon = other.GetComponentInChildren<Weapon>();
            if (currentWeapon != null)
            {
                // Melepaskan weapon yang sedang dipegang ke pickup point-nya semula
                currentWeapon.transform.SetParent(currentWeapon.parentTransform);
                currentWeapon.transform.localPosition = Vector3.zero;
                TurnVisual(false, currentWeapon); // Nonaktifkan visual dari weapon yang dilepaskan
            }

            // Memberikan weapon baru ke player
            weapon.transform.SetParent(other.transform);
            weapon.transform.localPosition = new Vector3(0, -0.05f, 0); // Set posisi weapon baru di player
            TurnVisual(true); // Aktifkan visual dari weapon yang baru
        }
    }

    void TurnVisual(bool state)
    {
        if (weapon != null)
        {
            // Aktifkan atau nonaktifkan semua komponen MonoBehaviour di dalam objek Weapon
            foreach (var component in weapon.GetComponentsInChildren<MonoBehaviour>())
            {
                component.enabled = state;
            }

            // Aktifkan atau nonaktifkan Animator
            Animator animator = weapon.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.enabled = state;
            }

            // Aktifkan atau nonaktifkan semua Renderer
            foreach (var renderer in weapon.GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = state;
            }
        }
    }

    void TurnVisual(bool state, Weapon weapon)
    {
        if (weapon != null)
        {
            // Aktifkan atau nonaktifkan semua komponen MonoBehaviour di dalam objek Weapon
            foreach (var component in weapon.GetComponentsInChildren<MonoBehaviour>())
            {
                component.enabled = state;
            }

            // Aktifkan atau nonaktifkan Animator
            Animator animator = weapon.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.enabled = state;
            }

            // Aktifkan atau nonaktifkan semua Renderer
            foreach (var renderer in weapon.GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = state;
            }
        }
    }
}
