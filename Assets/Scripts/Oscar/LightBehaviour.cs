using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    public Light Light;
    public Light pointLight;
    public bool lightOn;

    private void Start()
    {
        lightOn = true;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            if (lightOn == true)
            {
                lightOn = false;
            }
            else
            {
                lightOn = true;
            }
        }
    }
}
