using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform arm;
    public Vector3 offset;
    public Vector3 originalPos;
    void Update()
    {
        if(GAME_MANAGER._GAME_MANAGER.isGamePaused == false)
        {
            this.transform.position = arm.transform.position + offset;
        }
          
        
       
        
    }
}
