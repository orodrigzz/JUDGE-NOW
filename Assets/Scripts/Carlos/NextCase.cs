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
            GAME_MANAGER._GAME_MANAGER.lastScene = null;
            GAME_MANAGER._GAME_MANAGER.endDialogue = false;
            GAME_MANAGER._GAME_MANAGER.isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;
        }
        if(GAME_MANAGER._GAME_MANAGER.lastScene == "Game")
        {
            SceneManager.LoadScene("Case2");
            GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
            GAME_MANAGER._GAME_MANAGER.lastScene = null;
            GAME_MANAGER._GAME_MANAGER.endDialogue = false;
            GAME_MANAGER._GAME_MANAGER.isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;
        }
        if (GAME_MANAGER._GAME_MANAGER.lastScene == "Case2")
        {
            SceneManager.LoadScene("Case3");
            GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
            GAME_MANAGER._GAME_MANAGER.lastScene = null;
            GAME_MANAGER._GAME_MANAGER.endDialogue = false;
            GAME_MANAGER._GAME_MANAGER.isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;
        }
        if (GAME_MANAGER._GAME_MANAGER.lastScene == "Case3")
        {
            SceneManager.LoadScene("Win");
            GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
            GAME_MANAGER._GAME_MANAGER.lastScene = null;
            GAME_MANAGER._GAME_MANAGER.endDialogue = false;
            GAME_MANAGER._GAME_MANAGER.isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;
        }
    }
}
