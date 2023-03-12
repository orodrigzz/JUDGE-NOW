using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public  bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsUI;

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
    }

    public void Settings()
    {
        settingsUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Time.timeScale = 1f;
        GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
    }
    public void Resume()
    {
        Cursor.visible = false;
        if (pauseMenuUI != null && settingsUI != null)
        {
            pauseMenuUI.SetActive(false);
            settingsUI.SetActive(false);
        }   
        Time.timeScale = 1f;
        GameIsPaused = false;
        GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameIsPaused)
        {    
            Pause();                 
        }
        /*else if(Input.GetKeyDown(KeyCode.Escape) && GameIsPaused)
        {
            Resume();
        }*/
    }

    void Pause()
    {
              
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        GAME_MANAGER._GAME_MANAGER.isGamePaused = true;
        Cursor.visible = true;
        Time.timeScale = 0f;

    }
}
