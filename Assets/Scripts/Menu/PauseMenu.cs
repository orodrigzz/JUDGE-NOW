using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public  bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsUI;
    [Header("Get Scene")]
    public Scene currentScene;
    


    public void Menu()
    {
        GAME_MANAGER._GAME_MANAGER.isGamePaused = true;
        GAME_MANAGER._GAME_MANAGER.reputationCanvas.SetActive(false);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        
        pauseMenuUI.SetActive(false);
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
       
        /*else if(Input.GetKeyDown(KeyCode.Escape) && GameIsPaused)
        {
            Resume();
        }*/
      

            
            if (Input.GetKeyDown(KeyCode.Escape) && !GameIsPaused)
            {
                Pause();
            }
        
    }

    void Pause()
    {
              
        if(pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }
        GameIsPaused = true;
        GAME_MANAGER._GAME_MANAGER.isGamePaused = true;
        Cursor.visible = true;
        Time.timeScale = 0f;

    }
}
