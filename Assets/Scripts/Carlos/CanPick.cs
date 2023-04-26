using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPick : MonoBehaviour
{
    [SerializeField] MeshRenderer objectMaterial;
    [SerializeField] Material originalMaterial;
    [SerializeField] Material canSelect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GAME_MANAGER._GAME_MANAGER.isPicked)
        {
            objectMaterial.material = originalMaterial;
        }
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ObjectDetector" && GAME_MANAGER._GAME_MANAGER.isPicked == false)
        {

            objectMaterial.material = canSelect;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ObjectDetector" && GAME_MANAGER._GAME_MANAGER.isPicked == false)
        {
            objectMaterial.material = originalMaterial;

        }
    }
}
