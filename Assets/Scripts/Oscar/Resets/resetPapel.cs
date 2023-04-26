using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPapel : MonoBehaviour
{
    public NewDialogueSystem newDialogueSystem;

    [SerializeField] GameObject papelObj;
    [SerializeField] GameObject newPapel;
    [SerializeField] Transform resetObject;

    void Update()
    {
       papelObj = GameObject.FindGameObjectWithTag("Papel");

        if (newDialogueSystem != null)
        {
            if (newDialogueSystem.evidenceInstantiated == true)
            {
                if (papelObj == null)
                {
                    Instantiate(newPapel, resetObject, false);
                }
            }
        }

    }
}
