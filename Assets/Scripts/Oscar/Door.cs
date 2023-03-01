using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool openDoor = false;

    public float speed = 0.5f;
    public float openAngle = 90f;
    public float closeAngle = 0f;

    //public AudioClip openDoor;
    //public AudioClip closeDoor;

    void Update()
    {
        openDoor = true;

        if (openDoor)
        {
            Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, speed * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, closeAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, speed * Time.deltaTime);
        }

    }
}
