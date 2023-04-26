using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetServilleta : MonoBehaviour
{
    public NewDialogueSystem newDialogueSystem;

    [SerializeField] GameObject servilletaObj;
    [SerializeField] GameObject newServilleta;
    [SerializeField] Transform resetObject;

    void Update()
    {
        servilletaObj = GameObject.FindGameObjectWithTag("Servilleta");

        if (newDialogueSystem != null)
        {
            if (newDialogueSystem.evidenceInstantiated == true)
            {
                if (servilletaObj == null)
                {
                    Instantiate(newServilleta, resetObject, false);
                }
            }
        }

    }
}
