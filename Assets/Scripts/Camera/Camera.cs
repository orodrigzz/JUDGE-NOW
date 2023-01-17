using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField]
    private float targetDistance;

    [SerializeField]
    private float cameraLerp; //12f

    private float rotationX;
    private float rotationY;

    public float maxDistance;
    public float minDistance;

    public float minRotation = -50f;
    public float maxRotation = 50f;

    //private void Awake()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}

    private void LateUpdate()
    {
        targetDistance -= Input.mouseScrollDelta.y;
        if (targetDistance >= maxDistance)
        {
            targetDistance = maxDistance;
        }
        if (targetDistance <= minDistance)
        {
            targetDistance = minDistance;
        }

        rotationX += Input.GetAxis("Mouse Y");
        rotationY += Input.GetAxis("Mouse X");

        rotationX = Mathf.Clamp(rotationX, minRotation, maxRotation);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);


    }
}
