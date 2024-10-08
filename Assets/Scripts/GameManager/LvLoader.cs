using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LvLoader : MonoBehaviour
{
    int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void Reload()
    {
        // PlayerScript.playerScore = 0;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(currentIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
