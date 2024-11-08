using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float delayBeforeLoading = 2.0f; // Waktu delay sebelum memuat level berikutnya
    private float timeElapsed;

    void Update()
    {
        // Logika lain yang mungkin perlu dijalankan di level, seperti spawn point
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Jika ada level berikutnya, load level
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Sudah mencapai level terakhir.");
            // Bisa menambahkan logika untuk kembali ke main menu atau restart game
        }
    }

    public void ReloadCurrentLevel()
    {
        // Restart level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}