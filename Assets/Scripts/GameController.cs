using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject gameOverPanel;
    public Text scoreText;
    int score = 0;
    public Text BestScoreText;
    public Text YourScoreText;
    public GameObject newBestAlert;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        Invoke("ShowOverPanel", 1.0f);
    }
    void ShowOverPanel()
    {
        scoreText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        if(score > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", score);
            newBestAlert.SetActive(true);
        }

        BestScoreText.text = "Best Score : " + PlayerPrefs.GetInt("Best", 0).ToString();
        YourScoreText.text = "Your Score : " + score.ToString();
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

   public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
