using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerController : MonoBehaviour {

    public void NewGameBtn(int newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitGameBtn(string exitGameLevel)
    {
        Application.Quit();
    }

    public void LoadGameBtn(int loadGameLevel)
    {
        SceneManager.LoadScene(loadGameLevel);
    }

    public void HighScoreBtn(int loadGameLevel)
    {
        SceneManager.LoadScene(loadGameLevel);
    }
    public void InstuctionsBtn(int loadGameLevel)
    {
        SceneManager.LoadScene(loadGameLevel);
    }
}
