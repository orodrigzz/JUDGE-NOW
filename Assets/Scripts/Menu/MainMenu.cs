using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
        GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
        GAME_MANAGER._GAME_MANAGER.noise = 0;
        GAME_MANAGER._GAME_MANAGER.lastScene = null;
        GAME_MANAGER._GAME_MANAGER.endDialogue = false;

    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Menu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Case1()
    {
        SceneManager.LoadScene("Game");
    }
    public void Case2()
    {
        SceneManager.LoadScene("Case2");
    }

    public void Case3()
    {
        SceneManager.LoadScene("Case3");
    }
}
