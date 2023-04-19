using UnityEngine;

public class ResetComplainantFinger : MonoBehaviour
{
    public NewDialogueSystem newDialogueSystem;

    [SerializeField] GameObject fingerObj;
    [SerializeField] GameObject newfinger;
    [SerializeField] Transform resetObject;

    void Update()
    {
        fingerObj = GameObject.FindGameObjectWithTag("ComplainantFinger");
        if(newDialogueSystem != null)
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
