using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    public Light Light;
    public Light pointLight;
    
    public float timerLightOff;
    public float time;
    private void Start()
    {
        GAME_MANAGER._GAME_MANAGER.lightsOn = true;
        timerLightOff = time;
    }

    private void Update()
    {
        if (GAME_MANAGER._GAME_MANAGER.lightsOn == true)
        {
            timerLightOff = time;
            if (Light != null && pointLight != null)
            {
                Light.intensity = 0.5f;
                pointLight.intensity = 1;
            }
        }

        if (GAME_MANAGER._GAME_MANAGER.lightsOn == false)
        {
            if (Light != null && pointLight != null)
            {
                Light.intensity = 0f;
                pointLight.intensity = 0;
            }
        }

        if(GAME_MANAGER._GAME_MANAGER.noise >= 0.15)
        {
            timerLightOff -= Time.deltaTime;
            if(timerLightOff <= 0)
            {
                GAME_MANAGER._GAME_MANAGER.lightsOn = false;
            }
        }
    }

   
}
