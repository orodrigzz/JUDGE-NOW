using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetVibrator : MonoBehaviour
{
    public NewDialogueSystem newDialogueSystem;

    [SerializeField] GameObject vibratorObj;
    [SerializeField] GameObject newVibrator;
    [SerializeField] Transform resetObject;

    void Update()
    {
        vibratorObj = GameObject.FindGameObjectWithTag("Vibrador");

        if (newDialogueSystem != null)
        {
            if (newDialogueSystem.evidenceInstantiated == true)
            {
                if (vibratorObj == null)
                {
                    Instantiate(newVibrator, resetObject, false);
                }
            }
        }

    }
}
