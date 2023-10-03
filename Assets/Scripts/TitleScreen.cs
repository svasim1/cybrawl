using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void PlayTutorial()
    {
        SceneManager.LoadSceneAsync("Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
