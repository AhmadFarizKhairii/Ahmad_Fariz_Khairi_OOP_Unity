using UnityEngine;

public class StartTransition : MonoBehaviour
{
    private Vector3 startScale = new Vector3(0f, 0f, 0f); // Skala 0 di semua arah

    void Start()
    {
        // Mengatur skala objek menjadi 0 saat start
        transform.localScale = startScale;
        Debug.Log("Start transition: Skala diatur ke " + startScale);
    }

    public void TriggerStart()
    {
        // Tambahkan logika untuk memulai transisi
        transform.localScale = new Vector3(20f, 20f, 20f);
    }
}