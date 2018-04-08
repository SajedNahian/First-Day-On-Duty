using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    public GameObject joyStick, gameOverPanel;

    void Awake()
    {
        gameOverPanel.SetActive(false);    
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver ()
    {
        joyStick.SetActive(false);
        gameOverPanel.SetActive(true);
        PlayerMovement.gameOver = true;
    }
}
