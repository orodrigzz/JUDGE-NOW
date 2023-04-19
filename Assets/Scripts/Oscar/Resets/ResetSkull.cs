using UnityEngine;

public class ResetSkull : MonoBehaviour
{
    public NewDialogueSystem newDialogueSystem;

    [SerializeField] GameObject skullObj;
    [SerializeField] GameObject newSkull;
    [SerializeField] Transform resetObject;

    void Update()
    {
        skullObj = GameObject.FindGameObjectWithTag("Skull");

        if(newDialogueSystem != null)
        {
            if (newDialogueSystem.evidenceInstantiated == true)
            {
                if (skullObj == null)
                {
                    Instantiate(newSkull, resetObject, false);
                }
            }
        }
        
    }
}
