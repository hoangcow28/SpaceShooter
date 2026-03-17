using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFlow : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public PlayerHealth playerHealth;
    public EnemySpawner enemySpawner;

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

    private void Update()
    {
        if (isGameEnded) return;

        // nếu không còn enemy thì thắng
        if (EnemyHealth.LivingEnemyCount <= 0)
        {
            Invoke(nameof(OnGameWin), 0.3f);
        }
    }

    private System.Collections.IEnumerator WinDelay()
    {
        isGameEnded = true;

        yield return new WaitForSeconds(0.3f);

        OnGameWin();
    }

    public void GameOver()
    {
        if (isGameEnded) return;

        isGameEnded = true;

        gameOverUI.SetActive(true);

        if (bgMusic != null)
            bgMusic.SetActive(false);

        Time.timeScale = 0f;
    }

    private void OnGameWin()
    {
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