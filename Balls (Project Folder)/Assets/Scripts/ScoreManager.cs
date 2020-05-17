using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static int mCurrScore;
    public static TextMeshProUGUI highscoreText;
    public static TextMeshProUGUI currscoreText;
    static int mMultiplier = 1;
    static int mBallCount = 0;
    public TextMeshProUGUI howToText;
    float mTimer = 5.0f;

    void Start()
    {
        highscoreText = GameObject.FindGameObjectWithTag("UIHighscore").GetComponent<TextMeshProUGUI>();
        currscoreText = GameObject.FindGameObjectWithTag("UIScore").GetComponent<TextMeshProUGUI>();

        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0).ToString();
        currscoreText.text = "0";
    }

    void Update()
    {
        if (mTimer>0.0f)
        {
            mTimer -= Time.deltaTime;
            if (mTimer <= 0.0f)
            {
                howToText.enabled = false;
            }
        }
    }

    public static void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void UpdateScore()
    {
        mBallCount++;
        mCurrScore += mMultiplier;
        currscoreText.text = mCurrScore.ToString();
        //increase the multiplier for counts of 5
        if (mBallCount % 5 == 0)
        {
            mMultiplier++;
        }

        if (mCurrScore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", mCurrScore);
        }
    }
}
