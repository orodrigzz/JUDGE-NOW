using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool openDoor = false;

    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float closeAngle = 0f;

    public AudioSource doorOpening;
    //public AudioClip closeDoor;

    private void Start()
    {
        doorOpening.Play();
    }

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
