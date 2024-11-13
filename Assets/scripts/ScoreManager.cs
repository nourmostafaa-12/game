using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    private int score = 0;
    private int highscore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        UpdateScoreText();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        UpdateScoreText();

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
            highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString() + " POINTS";
    }
}
