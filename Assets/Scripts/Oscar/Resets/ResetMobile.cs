using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMobile : MonoBehaviour
{
    public NewDialogueSystem newDialogueSystem;

    [SerializeField] GameObject mobile;
    [SerializeField] GameObject newMobile;
    [SerializeField] Transform resetObject;

    void Update()
    {
        mobile = GameObject.FindGameObjectWithTag("Mobile");

        if (newDialogueSystem.evidenceInstantiated == true)
        {
            if (mobile == null)
            {
                Instantiate(newMobile, resetObject, false);
            }
        }
    }
}