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
            SceneManager.LoadScene("Day1");
            GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
            GAME_MANAGER._GAME_MANAGER.lastScene = null;
            GAME_MANAGER._GAME_MANAGER.endDialogue = false;
            GAME_MANAGER._GAME_MANAGER.isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;
        }
        if(GAME_MANAGER._GAME_MANAGER.lastScene == "Day1")
        {
            SceneManager.LoadScene("Scenario2");
            GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
            GAME_MANAGER._GAME_MANAGER.lastScene = null;
            GAME_MANAGER._GAME_MANAGER.endDialogue = false;
            GAME_MANAGER._GAME_MANAGER.isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;
        }
        if (GAME_MANAGER._GAME_MANAGER.lastScene == "Day2")
        {
            SceneManager.LoadScene("Scenario3");
            GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
            GAME_MANAGER._GAME_MANAGER.lastScene = null;
            GAME_MANAGER._GAME_MANAGER.endDialogue = false;
            GAME_MANAGER._GAME_MANAGER.isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;
        }
        if (GAME_MANAGER._GAME_MANAGER.lastScene == "Scenario3")
        {
            SceneManager.LoadScene("Day3");
            GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
            GAME_MANAGER._GAME_MANAGER.lastScene = null;
            GAME_MANAGER._GAME_MANAGER.endDialogue = false;
            GAME_MANAGER._GAME_MANAGER.isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;
        }
        if (GAME_MANAGER._GAME_MANAGER.lastScene == "Day3")
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
