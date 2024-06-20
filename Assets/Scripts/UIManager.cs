using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverPanel;
    public GameObject startUI;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.instance.score.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        highScoreText.text = "HIGHSCORE : " + PlayerPrefs.GetInt("HighScore");
    }

    public void StartUI()
    {
        startUI.SetActive(false);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
