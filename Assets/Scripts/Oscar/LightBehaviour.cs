using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    public GameObject Light;

    public bool lightOn;

    private void Start()
    {
        lightOn = true;
    }

    private void Update()
    {
        if (lightOn == true)
        {
            if (Light != null)
            {
                Light.GetComponent<Light>().range = 6;
            }
        }

        if (lightOn == false)
        {
            if (Light != null)
            {
                Light.GetComponent<Light>().range = 0;
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
