using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationPointBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] exclamationPoints;
    void Start()
    {
        if(exclamationPoints != null)
        {
            for (int i = 0; i < exclamationPoints.Length - 1; i++)
            {
                exclamationPoints[i].SetActive(false);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(exclamationPoints != null){

            if (GAME_MANAGER._GAME_MANAGER.isDialoging)
            {
                for (int i = 0; i < exclamationPoints.Length - 1; i++)
                {
                    exclamationPoints[i].SetActive(true);
                }
            }
            if (GAME_MANAGER._GAME_MANAGER.isDialoging == false)
            {
                for (int i = 0; i < exclamationPoints.Length - 1; i++)
                {
                    exclamationPoints[i].SetActive(false);
                }
            }
            if (GAME_MANAGER._GAME_MANAGER.currentScene.name == "Tutorial" && GAME_MANAGER._GAME_MANAGER.tutorialStarted)
            {
                for (int i = 0; i < exclamationPoints.Length - 1; i++)
                {
                    exclamationPoints[i].SetActive(true);
                }
            }
        }
        if (GAME_MANAGER._GAME_MANAGER.isGamePaused)
        {
            for (int i = 0; i < exclamationPoints.Length - 1; i++)
            {
                exclamationPoints[i].SetActive(false);
            }
        }
       
    }
}
