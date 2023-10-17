using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Tutorial");
    }

    public void PlayTutorial()
    {
        SceneManager.LoadSceneAsync("TutorialLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
