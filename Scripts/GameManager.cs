using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject startBtn;
    public Player birdBek;

    public Text gameOverTxt;
    public Text scoreText; // New UI Text for the score
    public float restartDelay = 5; // Time to wait before restarting

    private float timerBack; // Internal timer
    private int score; // New score variable

    private void Start() {
        gameOverTxt.gameObject.SetActive(false);
        scoreText.text = "Score: 0"; // Initialize score display
        Time.timeScale = 0f;  // Game starts paused
        timerBack = restartDelay;
    }

    private void Update() {
        if (birdBek.isDead) {
            gameOverTxt.gameObject.SetActive(true);
            timerBack -= Time.unscaledDeltaTime; // Count down
            gameOverTxt.text = "Restarting in " + timerBack.ToString("0");
            if (timerBack <= 0) {
                RestartGame();
            }
        } else {
            gameOverTxt.gameObject.SetActive(false);
            timerBack = restartDelay; // Reset timer when not dead
        }
    }

    public void StartGame() {
        startBtn.SetActive(false);
        birdBek.isDead = false;  // Reset player state
        Time.timeScale = 1;
        score = 0; // Reset score when starting the game
        scoreText.text = "Score: " + score; // Update score display
    }

    public void GameOver() {
        Time.timeScale = 0;
    }

    public void RestartGame() {
        EditorSceneManager.LoadScene(0); // Reload the scene
    }

    public void IncreaseScore() {
        score++; // Increase score by 1
        scoreText.text = "Score: " + score; // Update UI display
    }
}
