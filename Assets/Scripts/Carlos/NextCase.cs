using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextCase : MonoBehaviour
{
    public void Next()
    {
        if (GAME_MANAGER._GAME_MANAGER.lastScene == "Tutorial")
        {
            SceneManager.LoadScene("Game");
            GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
        }if(GAME_MANAGER._GAME_MANAGER.lastScene == "Game")
        {
            //TO DO
        }
    }
}
