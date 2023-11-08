using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject settingsPanel;

    void Update()
    {   
        // Pause the game when the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the pause menu
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
        // Activate the pause menu
        pauseMenu.SetActive(true);
        // Pause the timeScale
        Time.timeScale = 0;
    }

    public void Resume()
    {
        // Deactivate the pause menu and settings panel (if active)
        pauseMenu.SetActive(false);
        settingsPanel.SetActive(false);

        // Resume the timeScale
        Time.timeScale = 1;
    }

    public void TitleScreen()
    {
        // Reset the scores found in GameData.cs
        GameData.P1Score = 0;
        GameData.P2Score = 0;

        // Set the timeScale to 1 and load the title screen
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("TitleScreen");
    }

    // Open settings panel
    public void Settings()
    {
        // Set setings panel to active
        settingsPanel.SetActive(true);
    }
}
