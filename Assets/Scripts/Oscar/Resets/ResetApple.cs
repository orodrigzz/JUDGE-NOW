using UnityEngine;

public class ResetApple : MonoBehaviour
{
    public NewDialogueSystem newDialogueSystem;

    [SerializeField] GameObject appleObj;
    [SerializeField] GameObject newApple;
    [SerializeField] Transform resetObject;

    void Update()
    {
        appleObj = GameObject.FindGameObjectWithTag("Apple");

        if (newDialogueSystem.evidenceInstantiated == true)
        {
            if (appleObj == null)
            {
                Instantiate(newApple, resetObject, false);
            }
        }
    }
}
