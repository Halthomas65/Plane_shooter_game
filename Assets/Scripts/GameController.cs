using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    //  public GameObject resumeButton;
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject endText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        endText.SetActive(false);
        levelCompletePanel.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        // Time.timeScale = 0;
    }

    public IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(2);
        endText.SetActive(true);
        yield return new WaitForSeconds(3);

        levelCompletePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
