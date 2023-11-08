using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject settingsPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void TitleScreen()
    {
        GameData.P1Score = 0;
        GameData.P2Score = 0;
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("TitleScreen");
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
    }
}
