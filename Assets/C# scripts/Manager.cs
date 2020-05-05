using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public float slowDownFactor = 10f;
    public void EndGame()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        Time.timeScale = 1f / slowDownFactor;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowDownFactor;

        yield return new WaitForSeconds(1f / slowDownFactor);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
