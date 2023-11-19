using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set time scale to 1
        Time.timeScale = 1;
    }

    // Play the game
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("PVP1");
    }

    // Play the tutorial
    public void PlayTutorial()
    {
        SceneManager.LoadSceneAsync("Tutorial1");
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
