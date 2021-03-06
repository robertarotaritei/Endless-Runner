﻿using System.Collections;
using UnityEngine;

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
        Time.fixedDeltaTime /= slowDownFactor;

        yield return new WaitForSeconds(1f / slowDownFactor);

        Time.timeScale = 1f;
        Time.fixedDeltaTime *= slowDownFactor;
        FindObjectOfType<GameOverMenu>().gameIsOver = true;
    }
}
