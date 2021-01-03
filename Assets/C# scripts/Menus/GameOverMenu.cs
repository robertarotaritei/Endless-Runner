using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI;

    public GameObject score;

    public GameObject pauseButton;

    public bool gameIsOver = false;

    void Update()
    {
        if (gameIsOver)
        {
            gameOverMenuUI.SetActive(true);
            score.SetActive(false);
            pauseButton.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void Restart()
    {
        gameIsOver = false;
        gameOverMenuUI.SetActive(false);
        score.SetActive(true);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        gameIsOver = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
