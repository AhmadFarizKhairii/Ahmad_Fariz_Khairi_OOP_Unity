using UnityEngine;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour
{
    public Text healthText;      // UI text for player health
    public Text pointsText;      // UI text for game points
    public Text waveText;        // UI text for current wave number
    public Text enemyCountText;  // UI text for enemy count in current wave

    private Player player;        // Reference to Player script
    private GameManager gameManager; // Reference to GameManager script

    void Start()
    {
        // Get references to Player and GameManager scripts
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Update UI texts in real-time
        UpdateHealthText();
        UpdatePointsText();
        UpdateWaveText();
        UpdateEnemyCountText();
    }

    void UpdateHealthText()
    {
        healthText.text = $"Health: {player.GetCurrentHealth()}";
    }

    void UpdatePointsText()
    {
        pointsText.text = $"Points: {player.GetTotalPoints()}";
    }

    void UpdateWaveText()
    {
        waveText.text = $"Wave: {gameManager.GetCurrentWave()}";
    }

    void UpdateEnemyCountText()
    {
        enemyCountText.text = $"Enemies: {gameManager.GetRemainingEnemies()}";
    }
}