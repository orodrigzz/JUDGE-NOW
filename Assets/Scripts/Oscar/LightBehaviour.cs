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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            if (lightOn)
            {
                if (Light != null)
                {
                    Light.GetComponent<Light>().range = 0;
                }
            }
            else
            {
                if (Light != null)
                {
                    Light.GetComponent<Light>().range = 6;
                }
            }

        }
    }
}
