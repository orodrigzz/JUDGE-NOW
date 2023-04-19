using UnityEngine;

public class ResetDefendantFinger : MonoBehaviour
{
    public NewDialogueSystem newDialogueSystem;

    [SerializeField] GameObject fingerObj;
    [SerializeField] GameObject newfinger;
    [SerializeField] Transform resetObject;

    void Update()
    {
        fingerObj = GameObject.FindGameObjectWithTag("DefendantFinger");

        if (newDialogueSystem != null)
        {
            if (newDialogueSystem.evidenceInstantiated == true)
            {
                if (fingerObj == null)
                {
                    Instantiate(newfinger, resetObject, false);
                }
            }
        }
        
    }
}
