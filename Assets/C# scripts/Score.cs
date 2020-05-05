using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public float score = 0;
    public Text scoreText;
    public Text pauseScoreText;
    public Text highScoreText;
    public Material groundColor;
    public GameObject ground;
    private Color[] colors;
    private int colorNumber = -1;
    private bool changeColorOnce = true;

    void Start()
    {
        Color gray, blue, green, yellow, orange, red, black;

        gray = new Color(219 / 255f, 219 / 255f, 219 / 255f);
        blue = new Color(52 / 255f, 124 / 255f, 255 / 255f);
        green = new Color(52 / 255f, 255 / 255f, 66 / 255f);
        yellow = new Color(252 / 255f, 255 / 255f, 52 / 255f);
        orange = new Color(255 / 255f, 144 / 255f, 52 / 255f);
        red = new Color(205 / 255f, 12 / 255f, 0);
        black = new Color(0, 0, 0);
        colors = new Color[] { gray, blue, green, yellow, orange, red, black };
        scoreText.text = score.ToString();
        pauseScoreText.text = "Current score \n" + score.ToString();
        highScoreText.text = "High score \n" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        pauseScoreText.text = "Current score \n" + score.ToString();
        highScoreText.text = "High score \n" + PlayerPrefs.GetInt("HighScore", 0).ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score); 
        }

        if (FindObjectOfType<Score>().score % 10 == 0)
        {
            if (changeColorOnce)
            {
                colorNumber = (colorNumber + 1) % 7;
                StartCoroutine(BackgroundColorShifter(colorNumber));
                StartCoroutine(GroundColorShifter(colorNumber, groundColor));
                changeColorOnce = false;
            }
        }
        else
        {
            changeColorOnce = true;
        }
    }

    IEnumerator BackgroundColorShifter(int colorNumber)
    {
        var color = colors[colorNumber];
        var t = 0f;
        var currentColor = Camera.main.backgroundColor;
        while (t < 1.0)
        {
            Camera.main.backgroundColor = Color.Lerp(currentColor, color, t);
            yield return null;
            t += Time.deltaTime;
        }
    }
    IEnumerator GroundColorShifter(int colorNumber, Material groundColor)
    {
        var color = colors[colorNumber];
        var t = 0f;
        var currentColor = groundColor.color;
        while (t < 1.0)
        {
            groundColor.color = Color.Lerp(currentColor, color, t);
            ground.GetComponent<MeshRenderer>().material = groundColor;
            yield return null;
            t += Time.deltaTime;
        }
    }
}
