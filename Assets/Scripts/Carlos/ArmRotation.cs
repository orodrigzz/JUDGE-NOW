using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public float rotationSpeed = 5f;
    float rotationX;
    float rotationY;
    public GameObject root;
    Vector2 mouseDelta;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        mouseDelta =  InputManager._INPUT_MANAGER.GetDeltaMouse();       
        rotationX += mouseDelta.y;
        rotationY += mouseDelta.x;
        rotationY = Mathf.Clamp(rotationY, 1, 160f);
        rotationX = Mathf.Clamp(rotationX, -89f, 89f);
        if(mouseDelta.x != 0 ||  mouseDelta.y != 0)
        {
            root.transform.rotation = Quaternion.identity;
            Quaternion rot = Quaternion.Euler(0, rotationY, -rotationX);
            root.transform.rotation = rot;
        }

       


    }
}
