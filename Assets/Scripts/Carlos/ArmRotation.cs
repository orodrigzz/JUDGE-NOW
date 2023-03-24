using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    float rotationX;
    float rotationY;
    public GameObject root;
    Vector2 mouseDelta;
    [SerializeField] private bool fixy = false;
    [SerializeField] private float rotationxmax = 89;

    [SerializeField] Rigidbody rbPivot;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float maxZ;
    [SerializeField] float minZ;

    [SerializeField] float sensibility;
    [SerializeField] float velocity;

    [SerializeField]
    private string horizontalInputName = "Horizontal";

    [SerializeField]
    private string verticalInputName = "Vertical";

    private float horizontalInputValue;
    private float verticalInputValue;

    Vector3 originalPosition;

    private void Start()
    {
        originalPosition = rbPivot.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GAME_MANAGER._GAME_MANAGER.isGamePaused == false)
        {
            if(GAME_MANAGER._GAME_MANAGER.stopArmMovement == false)
            {
                mouseDelta = InputManager._INPUT_MANAGER.GetDeltaMouse();
                if (!fixy)
                {
                    rotationX += mouseDelta.y * sensibility;
                    rotationX = Mathf.Clamp(rotationX, -rotationxmax, rotationxmax);
                }
                else
                {
                    if (mouseDelta.y > 0)
                    {
                        rotationX += mouseDelta.y * sensibility;
                        rotationX = Mathf.Clamp(rotationX, -rotationxmax, rotationxmax);
                    }
                }
                rotationY += mouseDelta.x * sensibility;
                rotationY = Mathf.Clamp(rotationY, 1, 160f);

                if (mouseDelta.x != 0 || mouseDelta.y != 0)
                {
                    root.transform.rotation = Quaternion.identity;
                    Quaternion rot = Quaternion.Euler(0, rotationY, -rotationX);
                    root.transform.rotation = rot;
                }
                if (GAME_MANAGER._GAME_MANAGER.isInspecting == false)
                {
                    Vector3 currentPosition = rbPivot.transform.position;
                    horizontalInputValue = Input.GetAxis(horizontalInputName);
                    verticalInputValue = Input.GetAxis(verticalInputName);

                    float newX = currentPosition.x + horizontalInputValue * velocity * Time.deltaTime;
                    float newZ = currentPosition.z + verticalInputValue * velocity * Time.deltaTime;

                    newX = Mathf.Clamp(newX, minX, maxX);
                    newZ = Mathf.Clamp(newZ, minZ, maxZ);

                    Vector3 newPosition = new Vector3(newX, currentPosition.y, newZ);
                    rbPivot.MovePosition(newPosition);
                }
            
            }
            else
            {
                rbPivot.position = originalPosition;
            }
            
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Table")
        {
            fixy = true;
            //Debug.LogError("Enter");
        }
        if (other.gameObject.tag == "Hammer")
        {
            fixy = false;
            Debug.LogError("HammerTime");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Table")
        {
            fixy = false;
            //Debug.LogError("Enter");
        }
        if (other.gameObject.tag == "Hammer")
        {
            fixy = false;
            Debug.LogError("HammerExit");
        }
    }

}
