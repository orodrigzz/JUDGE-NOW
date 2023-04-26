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

    public GameObject judgality;
    public AudioSource judgalityAudio;
    public bool hasPlayedJudgability;
    private void Start()
    {
        startedCameraPosition = camera.transform.position;
        startedCameraRotation = camera.transform.rotation.eulerAngles;
        armHold.SetActive(false);
        arm.SetActive(true);
        judgality.SetActive(false);


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
            GAME_MANAGER._GAME_MANAGER.isHoldingSpace = true;
            if (itemPicked != null)
            {
                laserPointer.enabled = true;
                laserPointer.SetPositions(new Vector3[] { transform.position, transform.position + itemPicked.transform.right * 10f });
            }
            if (GAME_MANAGER._GAME_MANAGER.isHoldingSpace)
            {
                GAME_MANAGER._GAME_MANAGER.timeHolding += Time.deltaTime;
                if(GAME_MANAGER._GAME_MANAGER.timeHolding >= 1)
                {
                    
                   
                    GAME_MANAGER._GAME_MANAGER.objectVel = 850f;
                   
                }
                if (GAME_MANAGER._GAME_MANAGER.timeHolding >= 2)
                {
                    GAME_MANAGER._GAME_MANAGER.objectVel = 950f;
                }
                if (GAME_MANAGER._GAME_MANAGER.timeHolding >= 4)
                {
                    GAME_MANAGER._GAME_MANAGER.objectVel = 1000f;

                    if (GAME_MANAGER._GAME_MANAGER.isPickingHammer)
                    {
                        if (!hasPlayedJudgability)
                        {
                            judgalityAudio.Play();
                            hasPlayedJudgability = true;
                        }
                        GAME_MANAGER._GAME_MANAGER.decisionMode = true;
                        judgality.SetActive(true);
                        StartCoroutine(FJudgality());
                    }
                        
                    
                   
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
            GAME_MANAGER._GAME_MANAGER.isHoldingSpace = false;
            GAME_MANAGER._GAME_MANAGER.timeHolding = 0;
            GAME_MANAGER._GAME_MANAGER.objectVel = 800;
            hasPlayedJudgability = false;
            laserPointer.enabled = false;

        }
        
        if (Input.GetMouseButtonDown(0) && isPicked && itemPicked.tag != "Hammer")
        {
            if (GAME_MANAGER._GAME_MANAGER.isInspecting == false)
            {
                EnterInspectionMode();
                GAME_MANAGER._GAME_MANAGER.isDoneInspecting = false;
            }
            else if (GAME_MANAGER._GAME_MANAGER.isInspecting == true)
            {
                GAME_MANAGER._GAME_MANAGER.isDoneInspecting = true; 
                ExitInspectionMode();
            }
            
        }

        if(itemPicked != null)
        {
            if (itemPicked.tag == "Hammer")
            {
                GAME_MANAGER._GAME_MANAGER.isPickingHammer = true;
            }
            else
            {
                GAME_MANAGER._GAME_MANAGER.isPickingHammer = false;
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

            if (itemPicked.tag == "DefendantFinger")
            {
                offset = 0.35f;
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
            else if (itemPicked.tag == "ComplainantFinger")
            {
                offset = 0.35f;
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
            else if (itemPicked.tag == "Servilleta")
            {
                offset = 0.47f;
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
                offset = 0.47f;
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
           // Debug.Log("LOLOLOLO");
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

    IEnumerator FJudgality()
    {
        yield return new WaitForSeconds(12);
        judgality.SetActive(false);
        GAME_MANAGER._GAME_MANAGER.decisionMode = false;
    }
}
