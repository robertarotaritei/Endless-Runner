using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject score;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && FindObjectOfType<GameOverMenu>().gameIsOver == false)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        gameIsPaused = !gameIsPaused;
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        score.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        gameIsPaused = !gameIsPaused;
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        score.SetActive(false);
        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
