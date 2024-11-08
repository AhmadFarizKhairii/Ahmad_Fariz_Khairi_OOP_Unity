using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instance GameManager untuk akses global
    public int playerLives = 3;
    public bool isGameOver = false;

    private void Awake()
    {
        // Membuat GameManager menjadi singleton agar hanya ada satu instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Jangan hancurkan GameManager saat berpindah scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoseLife()
    {
        playerLives--;

        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
        // Bisa tambahkan logika untuk menampilkan UI Game Over atau restart level
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart level
        playerLives = 3; // Reset nyawa
        isGameOver = false;
    }
}
