using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    #region PickObject
    public Vector3[] rayOrigins;
    public LayerMask layer;
    public GameObject parent;
    public Rigidbody itemPicked;
    public bool isPicked = false;
    #endregion
    #region InspectObject
    [SerializeField] GameObject arm;
    [SerializeField] Camera camera;
    [SerializeField] Vector3 originaPosition;
    [SerializeField] Vector3 originalRotation;
    [SerializeField] Vector3 cameraOriginaPosition;
    [SerializeField] Vector3 cameraOriginalRotation;
    [SerializeField] Vector3 startedCameraPosition;
    [SerializeField] Vector3 startedCameraRotation;
    [SerializeField] float rotationSpeed;
    [SerializeField] float offset;
    public bool isInspecting;

    #endregion


    private void Start()
    {
        startedCameraPosition = camera.transform.position;
        startedCameraRotation = camera.transform.rotation.eulerAngles;
    }
    private void Update()
    {
            foreach (Vector3 origin in rayOrigins)
            {
                Ray ray = new Ray(transform.position + origin, transform.forward);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit,10f, layer))
                {
                    
                    if (Input.GetMouseButtonDown(0) && !isPicked)
                    {
                        itemPicked = hit.rigidbody;
                        itemPicked.transform.localScale = transform.parent.localScale;
                        itemPicked.transform.rotation = transform.parent.rotation;                        
                        itemPicked.transform.SetParent(parent.transform);                                        
                        if (itemPicked != null)
                        {
                            itemPicked.useGravity = false;
                            itemPicked.constraints = RigidbodyConstraints.FreezeAll;
                            isPicked = true;
                            GAME_MANAGER._GAME_MANAGER.isPicked = true;
                        }

                    }
            }
            else
            {
                if (Input.GetMouseButtonDown(1))
                {
                    
                    if(itemPicked != null)
                    {
                        itemPicked.transform.SetParent(null);
                        itemPicked.useGravity = true;
                        itemPicked.constraints = RigidbodyConstraints.None;
                    }
                        itemPicked = null;
                        isPicked = false;
                        GAME_MANAGER._GAME_MANAGER.isPicked = false;
                }
            }
           
                Debug.DrawRay(transform.position + origin, transform.forward * 100, Color.green);
            }

        if (Input.GetKeyDown(KeyCode.E))
        {
            EnterInspectionMode();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ExitInspectionMode();
        }
        if (isInspecting)
        {
            InspectObject();
        }
        
    }

    void EnterInspectionMode()
    {
        if(itemPicked != null)
        {
            originalRotation = itemPicked.transform.rotation.eulerAngles;
            originaPosition = itemPicked.transform.position;
            cameraOriginalRotation = camera.transform.rotation.eulerAngles;
            cameraOriginaPosition = camera.transform.position;
            camera.transform.position = startedCameraPosition;
            camera.transform.eulerAngles = startedCameraRotation;
            itemPicked.transform.position = camera.transform.position + (camera.transform.forward * offset);
            arm.SetActive(false);
            isInspecting = true;
            GAME_MANAGER._GAME_MANAGER.isGamePaused = true;
        }      
    }

    void ExitInspectionMode()
    {
        if (isInspecting)
        {
            itemPicked.transform.position = originaPosition;
            itemPicked.transform.eulerAngles = originalRotation;
            camera.transform.position = cameraOriginaPosition;
            camera.transform.eulerAngles = cameraOriginalRotation;
            arm.SetActive(true);
            isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.isGamePaused = false;
        }

    }
    void InspectObject()
    {
        float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
        float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

        itemPicked.transform.Rotate(Vector3.up, -xAxis, Space.World);
        itemPicked.transform.Rotate(Vector3.right, yAxis, Space.World);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, camera.transform.position + (camera.transform.forward * offset));
    }
}
