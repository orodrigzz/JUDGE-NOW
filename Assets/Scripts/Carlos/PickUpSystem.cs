using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    #region PickObject
    public LayerMask layer;
    public GameObject parent;
    public GameObject armHold;
    public Rigidbody itemPicked;
    public Collider colliderDetector;
    public bool isPicked = false;
    private Vector3 xOfsset = new Vector3(0.2f, 0,0);
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
    [SerializeField] GameObject evidenceOriginalPosition;
    [SerializeField] GameObject rulesOriginalPosition;
    [SerializeField] Vector3 originalScale;
    [SerializeField] Vector3 scaledScale;
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
        if (itemPicked != null)
        {
            throwableObject = itemPicked.GetComponent<ThrowableObject>();
        }
        #region InputsPickUp&Inspect
        if (Input.GetMouseButtonDown(1)  && !isInspecting  && GAME_MANAGER._GAME_MANAGER.isGamePaused == false)
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
            GAME_MANAGER._GAME_MANAGER.isPickingHammer = false;
            GAME_MANAGER._GAME_MANAGER.isHoldingSpace = false;
            GAME_MANAGER._GAME_MANAGER.objectVel = 800;
        }
        
        
            if (Input.GetKey(KeyCode.Space) && itemPicked != null && GAME_MANAGER._GAME_MANAGER.isGamePaused == false)
            {
                if (GAME_MANAGER._GAME_MANAGER.stopArmMovement == false)
                {
                    GAME_MANAGER._GAME_MANAGER.isHoldingSpace = true;
                    if (itemPicked != null)
                    {
                        laserPointer.enabled = true;
                        laserPointer.SetPositions(new Vector3[] { transform.position, transform.position + itemPicked.transform.right * 10f });
                    }


                    if (GAME_MANAGER._GAME_MANAGER.isHoldingSpace && GAME_MANAGER._GAME_MANAGER.stopArmMovement == false)
                    {
                        GAME_MANAGER._GAME_MANAGER.timeHolding += Time.deltaTime;
                            if (GAME_MANAGER._GAME_MANAGER.timeHolding >= 1)
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
                                        if (GAME_MANAGER._GAME_MANAGER.initDialogue == true)
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
                }
            }
        
        if (Input.GetKeyUp(KeyCode.Space) && GAME_MANAGER._GAME_MANAGER.isInspecting == false && GAME_MANAGER._GAME_MANAGER.isGamePaused == false)
        {
            if (throwableObject != null)
            {
                throwableObject.Throw();
            }

            if (itemPicked != null && GAME_MANAGER._GAME_MANAGER.stopArmMovement == false)
            {

                itemPicked.transform.SetParent(null);
                itemPicked.useGravity = true;
                itemPicked.constraints = RigidbodyConstraints.None;
                GAME_MANAGER._GAME_MANAGER.isPicked = false;
                itemPicked = null;
                isPicked = false;
                GAME_MANAGER._GAME_MANAGER.isHoldingSpace = false;
                GAME_MANAGER._GAME_MANAGER.isPickingHammer = false;
                GAME_MANAGER._GAME_MANAGER.timeHolding = 0;
                GAME_MANAGER._GAME_MANAGER.objectVel = 800;
                hasPlayedJudgability = false;
                laserPointer.enabled = false;

            }
            

        }

        if(itemPicked != null && itemPicked.tag != "Hammer")
        {
            if (Input.GetMouseButtonDown(0))
            {

                GAME_MANAGER._GAME_MANAGER.isInspecting = !GAME_MANAGER._GAME_MANAGER.isInspecting;
                
                
                if (GAME_MANAGER._GAME_MANAGER.isInspecting && itemPicked.tag != "Hammer" && itemPicked != null && GAME_MANAGER._GAME_MANAGER.isGamePaused == false)
                {
                    ExitInspectionMode();
                   

                }





            }
        }
        if (isInspecting)
        {
            if(GAME_MANAGER._GAME_MANAGER.isGamePaused == false)
            {
                InspectObject();
            }
            


        }

        if (itemPicked != null)
        {
            GAME_MANAGER._GAME_MANAGER.isPicked = true;
            if (itemPicked.tag == "Hammer")
            {
                GAME_MANAGER._GAME_MANAGER.isPickingHammer = true;
                
                
            }
            else
            {
                GAME_MANAGER._GAME_MANAGER.isPickingHammer = false;
                
            }
        }

        
        if (itemPicked == null)
        {
            laserPointer.enabled = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;

        }
        if(GAME_MANAGER._GAME_MANAGER.stopArmMovement == true)
        {
            laserPointer.enabled = false;
        }

        #endregion

    }

    void EnterInspectionMode()
    {
        if(itemPicked != null)
        {
           

                offset = 1;
                GAME_MANAGER._GAME_MANAGER.isInspecting = true;
                GAME_MANAGER._GAME_MANAGER.isPicked = true;
                isPicked = true;    
                isInspecting = true;
                originalScale = itemPicked.transform.localScale;
                cameraOriginalRotation = camera.transform.rotation.eulerAngles;
                cameraOriginaPosition = camera.transform.position;
                camera.transform.position = cameraOriginaPosition;
                camera.transform.eulerAngles = cameraOriginalRotation;
                scaledScale = originalScale * 2f;
                itemPicked.transform.position = (startedCameraPosition + xOfsset) + (camera.transform.forward * offset);
                itemPicked.transform.localScale = scaledScale;
                
                armHold.SetActive(false);
                arm.SetActive(false);
                colliderDetector.enabled = false;
                GAME_MANAGER._GAME_MANAGER.stopArmMovement = true;
                laserPointer.enabled = false;

        }      
    }

    void ExitInspectionMode()
    {
        if (GAME_MANAGER._GAME_MANAGER.isInspecting)
        {
            itemPicked.GetComponent<Collider>().enabled = true;
            itemPicked.transform.localScale = originalScale;
            itemPicked.transform.position = originaPosition;
            itemPicked.transform.eulerAngles = originalRotation;
            camera.transform.position = cameraOriginaPosition;
            camera.transform.eulerAngles = cameraOriginalRotation;
            armHold.SetActive(true);
            arm.SetActive(false);
            GAME_MANAGER._GAME_MANAGER.isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.isPicked = false;
            GAME_MANAGER._GAME_MANAGER.isDoneInspecting = true;
            colliderDetector.enabled = true;
            isInspecting = false;
            GAME_MANAGER._GAME_MANAGER.stopArmMovement = false;
            itemPicked = null;
            isPicked = false;
            laserPointer.enabled = true;
            
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
        if (other.gameObject.layer == 7 )
        {
            
            GAME_MANAGER._GAME_MANAGER.isInspecting = false;
            isInspecting = false;
           
            if (Input.GetMouseButtonDown(0) && !isPicked && !isInspecting && GAME_MANAGER._GAME_MANAGER.isInspecting == false && GAME_MANAGER._GAME_MANAGER.stopArmMovement == false)
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
        if (other.gameObject.layer == 10 )
        {
            
            if (Input.GetMouseButtonDown(0) && !isPicked)
            {

                armHold.SetActive(true);
                GAME_MANAGER._GAME_MANAGER.isPicked = true;
                arm.SetActive(false);
                itemPicked = other.gameObject.GetComponent<Rigidbody>();
                isPicked = true;
                EnterInspectionMode();
                GAME_MANAGER._GAME_MANAGER.isInspecting = true;
                itemPicked.transform.localScale = scaledScale;
                originalRotation = evidenceOriginalPosition.transform.rotation.eulerAngles;
                originaPosition = evidenceOriginalPosition.transform.position;
                itemPicked.GetComponent<Collider>().enabled = false;
            }

        }
        if (other.gameObject.layer == 11)
        {
            Debug.Log("papapapap");

            if (Input.GetMouseButtonDown(0) && !isPicked)
            {
                originaPosition = rulesOriginalPosition.transform.position;
                originalRotation = rulesOriginalPosition.transform.rotation.eulerAngles;
                armHold.SetActive(true);
                GAME_MANAGER._GAME_MANAGER.isPicked = true;
                arm.SetActive(false);
                itemPicked = other.gameObject.GetComponent<Rigidbody>();
                isPicked = true;
                originalScale = itemPicked.transform.localScale;
                scaledScale = originalScale * 1f;
                itemPicked.transform.localScale = scaledScale;
                
               
                EnterInspectionMode();
                GAME_MANAGER._GAME_MANAGER.isInspecting = true;


            }

        }
    }

    IEnumerator FJudgality()
    {
        yield return new WaitForSeconds(6);
        judgality.SetActive(false);
    }
}
