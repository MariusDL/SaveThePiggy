using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = "High score: " + highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameManager instance;

    public GameObject gameOverPanel;

    bool gameOver = false;

    int score = 0, highScore = 0;

    public Text scoreText;
    public Text scoreTextPanel;
    public Text highScoreText;

    private const string highScoreKey = "HighScore";


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    public void GameOver()
    {
        gameOver = true;
        GameObject.Find("EnemySpawn").GetComponent<EnemySpawner>().StopSpawning();
        scoreTextPanel.text  = "Score: " + score;
        SetHighScore();
        gameOverPanel.SetActive(true);

    }

    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
            
        }
        
    }

    public void SetHighScore()
    {
        if (score > highScore)
        {
            highScoreText.text ="High score: " + score.ToString();

            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
        }
    }

    public int ReturnScore()
    {
        return score;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

}
