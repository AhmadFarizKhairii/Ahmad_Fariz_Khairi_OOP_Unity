using UnityEngine;

public class EndTransition : MonoBehaviour
{
    private Vector3 endScale = new Vector3(20f, 20f, 20f); // Skala 20 di semua arah

    void Start()
    {
        // Mengatur skala objek menjadi 20 saat end
        transform.localScale = endScale;
        Debug.Log("End transition: Skala diatur ke " + endScale);
    }

    public void TriggerEnd()
    {
        // Tambahkan logika untuk mengakhiri transisi
        transform.localScale = new Vector3(0f, 0f, 0f);
    }
}