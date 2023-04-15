using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    #region PickObject
    public Vector3[] rayOrigins;
    public LayerMask layer;
    public GameObject parent;
    public GameObject armHold;
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
    public bool isInspecting = false;

    #endregion

    #region ThrowHammerMechanic
    [SerializeField] ThrowableObject throwableObject;
    [SerializeField] LineRenderer laserPointer;
    [SerializeField] Transform point0;
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    
    #endregion

    private void Start()
    {
        startedCameraPosition = camera.transform.position;
        startedCameraRotation = camera.transform.rotation.eulerAngles;
        armHold.SetActive(false);
        arm.SetActive(true);
       
        laserPointer.enabled = false;
       
    }

    private void Update()
    {
        if(itemPicked != null)
        {
            throwableObject = itemPicked.GetComponent<ThrowableObject>();
        }

       
        
        if (Input.GetMouseButtonDown(1) && GAME_MANAGER._GAME_MANAGER.isInspecting == false)
        {
            armHold.SetActive(false);
            arm.SetActive(true);

            if (itemPicked != null)
            {
                itemPicked.transform.SetParent(null);
                itemPicked.useGravity = true;
                itemPicked.constraints = RigidbodyConstraints.None;
            }
            if (GAME_MANAGER._GAME_MANAGER.endDialogue)
            {
               
            }
            itemPicked = null;
            isPicked = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;
        }
        if(Input.GetKey(KeyCode.Space) && GAME_MANAGER._GAME_MANAGER.isInspecting == false)
        {
           
            if(itemPicked != null)
            {
                laserPointer.enabled = true;

                laserPointer.positionCount = 200;
                float t = 0f;
                Vector3 B = new Vector3(0, 0, 0);
                for (int i = 0; i < laserPointer.positionCount; i++)
                {
                    B = (1 - t) * (1 - t) * point0.position + 2 * (1 - t) * t * point1.position + t * t * point2.position;
                    laserPointer.SetPosition(i, B);
                    t += (1 / (float)laserPointer.positionCount);
                }

                

            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space) && GAME_MANAGER._GAME_MANAGER.isInspecting == false)
        {
            if(throwableObject != null)
            {
                throwableObject.Throw();
            }
            
            if (itemPicked != null)
            {
                itemPicked.transform.SetParent(null);
                itemPicked.useGravity = true;
                itemPicked.constraints = RigidbodyConstraints.None;
            }
            itemPicked = null;
            isPicked = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;
            laserPointer.enabled = false;
        }
        
        if (Input.GetMouseButtonDown(0) && isPicked && itemPicked.tag != "Hammer")
        {
            if (GAME_MANAGER._GAME_MANAGER.isInspecting == false)
            {
                EnterInspectionMode();
            }
            else if (GAME_MANAGER._GAME_MANAGER.isInspecting == true)
            {
                ExitInspectionMode();
            }

        }
        if (GAME_MANAGER._GAME_MANAGER.isInspecting)
        {
            InspectObject();
        }
    }

    void EnterInspectionMode()
    {
        if(itemPicked != null)
        {

            if (itemPicked.tag == "Fingerprint")
            {
                offset = 0.4f;
                GAME_MANAGER._GAME_MANAGER.isInspecting = true;
                isInspecting = true;
                originalRotation = parent.transform.rotation.eulerAngles;
                originaPosition = parent.transform.position;
                cameraOriginalRotation = camera.transform.rotation.eulerAngles;
                cameraOriginaPosition = camera.transform.position;
                camera.transform.position = startedCameraPosition;
                camera.transform.eulerAngles = startedCameraRotation;
                itemPicked.transform.position = camera.transform.position + (camera.transform.forward * offset);
                armHold.SetActive(false);
                arm.SetActive(false);
                GAME_MANAGER._GAME_MANAGER.stopArmMovement = true;
               
            }
            else if (itemPicked.tag == "Skull")
            {
                offset = 0.45f;
                GAME_MANAGER._GAME_MANAGER.isInspecting = true;
                isInspecting = true;
                originalRotation = parent.transform.rotation.eulerAngles;
                originaPosition = parent.transform.position;
                cameraOriginalRotation = camera.transform.rotation.eulerAngles;
                cameraOriginaPosition = camera.transform.position;
                camera.transform.position = startedCameraPosition;
                camera.transform.eulerAngles = startedCameraRotation;
                itemPicked.transform.position = camera.transform.position + (camera.transform.forward * offset);
                armHold.SetActive(false);
                arm.SetActive(false);
                GAME_MANAGER._GAME_MANAGER.stopArmMovement = true;
                
            }
            else if (itemPicked.tag == "Mobile")
            {
                offset = 0.7f;
                GAME_MANAGER._GAME_MANAGER.isInspecting = true;
                isInspecting = true;
                originalRotation = parent.transform.rotation.eulerAngles;
                originaPosition = parent.transform.position;
                cameraOriginalRotation = camera.transform.rotation.eulerAngles;
                cameraOriginaPosition = camera.transform.position;
                camera.transform.position = startedCameraPosition;
                camera.transform.eulerAngles = startedCameraRotation;
                itemPicked.transform.position = camera.transform.position + (camera.transform.forward * offset);
                armHold.SetActive(false);
                arm.SetActive(false);
                GAME_MANAGER._GAME_MANAGER.stopArmMovement = true;
                
            }
            else
            {
                offset = 1;
                GAME_MANAGER._GAME_MANAGER.isInspecting = true;
                isInspecting = true;
                originalRotation = parent.transform.rotation.eulerAngles;
                originaPosition = parent.transform.position;
                cameraOriginalRotation = camera.transform.rotation.eulerAngles;
                cameraOriginaPosition = camera.transform.position;
                camera.transform.position = startedCameraPosition;
                camera.transform.eulerAngles = startedCameraRotation;
                itemPicked.transform.position = camera.transform.position + (camera.transform.forward * offset);
                armHold.SetActive(false);
                arm.SetActive(false);
                GAME_MANAGER._GAME_MANAGER.stopArmMovement = true;
               
            }
        }      
    }

    void ExitInspectionMode()
    {
        if (GAME_MANAGER._GAME_MANAGER.isInspecting)
        {
            itemPicked.transform.position = originaPosition;
            itemPicked.transform.eulerAngles = originalRotation;
            camera.transform.position = cameraOriginaPosition;
            camera.transform.eulerAngles = cameraOriginalRotation;
            armHold.SetActive(true);
            arm.SetActive(false);
            GAME_MANAGER._GAME_MANAGER.isInspecting = false;
            isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.stopArmMovement = false;
            
        }

    }
    void InspectObject()
    {
        float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
        float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;
        if(itemPicked != null)
        {
            itemPicked.transform.Rotate(Vector3.up, -xAxis, Space.World);
            itemPicked.transform.Rotate(Vector3.right, yAxis, Space.World);
        }
        
    }

   

   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            
            if (Input.GetMouseButtonDown(0) && !isPicked)
            {
                armHold.SetActive(true);
                arm.SetActive(false);
                itemPicked = other.gameObject.GetComponent<Rigidbody>();
                itemPicked.transform.localScale = transform.parent.localScale;
                itemPicked.transform.rotation = parent.transform.rotation;
                itemPicked.transform.SetParent(parent.transform);
                itemPicked.transform.localPosition = parent.transform.localPosition;
               
                if (itemPicked != null)
                {
                    itemPicked.useGravity = false;
                    itemPicked.constraints = RigidbodyConstraints.FreezeAll;
                    isPicked = true;
                    GAME_MANAGER._GAME_MANAGER.isPicked = true;
                }
            }

        }
    }
}
