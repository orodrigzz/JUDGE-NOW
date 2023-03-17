using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHammer : MonoBehaviour
{
    [SerializeField] GameObject hammerObj;
    [SerializeField] GameObject newHammer;
    [SerializeField] Transform resetObject;

    void Update()
    {
        hammerObj = GameObject.FindGameObjectWithTag("Hammer");

        if(hammerObj == null)
        {
            Instantiate(newHammer, resetObject, false);

        }
    }
}
