using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDecision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand")
        {
            if(GAME_MANAGER._GAME_MANAGER.decisionMode == false)
            {
                GAME_MANAGER._GAME_MANAGER.decisionMode = true;
            }
            else
            {
                GAME_MANAGER._GAME_MANAGER.decisionMode = false;
            }
        }
    }
}
