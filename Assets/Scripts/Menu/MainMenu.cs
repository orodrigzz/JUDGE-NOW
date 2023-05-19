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
    public void Day1()
    {
        SceneManager.LoadScene("Day1");
    }
    public void Day2()
    {
        SceneManager.LoadScene("Day2");
    }

    public void Day3()
    {
        SceneManager.LoadScene("Day3");
    }
}
