using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    public Light Light;
    public Light pointLight;
    public bool lightOn;
    public float timerLightOff;
    public float time;
    private void Start()
    {
        lightOn = true;
        time = timerLightOff;
    }

    private void Update()
    {
        if (lightOn == true)
        {
            if (Light != null && pointLight != null)
            {
                Light.intensity = 0.5f;
                pointLight.intensity = 1;
            }
        }

        if (lightOn == false)
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
                lightOn = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            if (lightOn == false)
            {
                lightOn = true;
                time = timerLightOff;
            }
            
        }
    }
}
