using UnityEngine;

public class ResetApple : MonoBehaviour
{
    public TutorialManagager tutorialManagager;

    [SerializeField] GameObject appleObj;
    [SerializeField] GameObject newApple;
    [SerializeField] Transform resetObject;

    void Update()
    {
        appleObj = GameObject.FindGameObjectWithTag("Apple");


        if(tutorialManagager != null)
        {
            if (tutorialManagager.hasSpawned == true)
            {
                if (appleObj == null)
                {
                    Instantiate(newApple, resetObject, false);
                }
            }
        }
        
    }
}
