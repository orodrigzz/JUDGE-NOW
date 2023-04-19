using UnityEngine;

public class ResetBittedApple : MonoBehaviour
{
    public NewDialogueSystem newDialogueSystem;

    [SerializeField] GameObject appleObj;
    [SerializeField] GameObject newApple;
    [SerializeField] Transform resetObject;

    void Update()
    {
        appleObj = GameObject.FindGameObjectWithTag("BittedApple");

        if(newDialogueSystem != null)
        {
            if (newDialogueSystem.evidenceInstantiated == true)
            {
                if (appleObj == null)
                {
                    Instantiate(newApple, resetObject, false);
                }
            }
        }
        
    }
}
