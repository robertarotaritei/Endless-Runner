using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public float score = 0;
    public Text scoreText;
    public Text pauseScoreText;
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        pauseScoreText.text = "Current score \n" + score.ToString();
        highScoreText.text = "High score \n" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        pauseScoreText.text = "Current score \n" + score.ToString();
        highScoreText.text = "High score \n" + PlayerPrefs.GetInt("HighScore", 0).ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score); 
        }
    }
}
