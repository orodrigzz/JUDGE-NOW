using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public  bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsUI;
    public bool isMenu;
    [Header("Get Scene")]
    public Scene currentScene;
    public string nameScene;
    


    public void Menu()
    {
        
        GAME_MANAGER._GAME_MANAGER.reputationCanvas.SetActive(false);
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
        GAME_MANAGER._GAME_MANAGER.menuOpen = false;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Cursor.visible = true;
        
    }

    public void Settings()
    {
        settingsUI.SetActive(true);
        
        GAME_MANAGER._GAME_MANAGER.isGamePaused = true;

    }
    public void Back()
    {
        settingsUI.SetActive(false);
        GAME_MANAGER._GAME_MANAGER.isGamePaused = true;
        
    }

    public void Quit()
    {
        Application.Quit();
        Time.timeScale = 1f;
        GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
    }
    public void Resume()
    {
        GAME_MANAGER._GAME_MANAGER.menuOpen = false;
        GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
        GameIsPaused = false;
        Cursor.visible = false;
        Time.timeScale = 1f;
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            settingsUI.SetActive(false);
        }

        

    }

    private void Update()
    {

        /*else if(Input.GetKeyDown(KeyCode.Escape) && GameIsPaused)
        {
            Resume();
        }*/



        if (Input.GetKeyDown(KeyCode.Escape) && !GameIsPaused && GAME_MANAGER._GAME_MANAGER.isMenu == false)
        {
            Pause();
            GAME_MANAGER._GAME_MANAGER.menuOpen = true;

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
        
        Time.timeScale = 0f;

    }
}
