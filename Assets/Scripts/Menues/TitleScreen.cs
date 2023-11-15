using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
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
