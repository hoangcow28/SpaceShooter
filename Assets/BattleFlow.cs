using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFlow : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public PlayerHealth playerHealth;
    public GameObject bgMusic;

    private bool isGameEnded = false;

    private void Start()
    {
        Time.timeScale = 1f;

        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);

        if (playerHealth != null)
            playerHealth.onDead += GameOver;
    }

    public void GameOver()
    {
        if (isGameEnded) return;

        isGameEnded = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (isGameEnded) return;

        if (EnemyHealth.LivingEnemyCount == 0)
        {
            OnGameWin();
        }
    }

    private void OnGameWin()
    {
        isGameEnded = true;

        gameWinUI.SetActive(true);

        if (bgMusic != null)
            bgMusic.SetActive(false);

        if (playerHealth != null)
            playerHealth.gameObject.SetActive(false);

        Time.timeScale = 0f;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}