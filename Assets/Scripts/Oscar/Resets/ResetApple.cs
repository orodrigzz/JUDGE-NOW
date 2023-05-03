using UnityEngine;

public class ResetApple : MonoBehaviour
{
   

    [SerializeField] GameObject appleObj;
    [SerializeField] GameObject newApple;
    [SerializeField] Transform resetObject;

    void Update()
    {
        appleObj = GameObject.FindGameObjectWithTag("Apple");
          if (appleObj == null)
          {
            Instantiate(newApple, resetObject, false);
          }
            
        
        
    }
}
