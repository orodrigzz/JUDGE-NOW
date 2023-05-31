using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    public Light Light;
    public Light pointLight;
    public Light[] pointLights;
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
            if (Light != null && pointLight != null)
            {
                Light.intensity = 0.5f;
                pointLight.intensity = 1;
            }
            for(int i =0; i < pointLights.Length; i++)
            {
                pointLights[i].intensity = 1;
            }
        }

        if (GAME_MANAGER._GAME_MANAGER.lightsOn == false)
        {
            if (Light != null && pointLight != null)
            {
                Light.intensity = 0f;
                pointLight.intensity = 0;
            }
            for (int i = 0; i < pointLights.Length; i++)
            {
                pointLights[i].intensity = 0;
            }
        }

        if(GAME_MANAGER._GAME_MANAGER.noise > 0.1)
        {
            timerLightOff -= Time.deltaTime;
            if(timerLightOff <= 0)
            {
                GAME_MANAGER._GAME_MANAGER.lightsOn = false;
            }
        }
    }

   
}
