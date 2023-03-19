using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform arm;
    public Vector3 offset;
    void Update()
    {
        this.transform.position = arm.transform.position + offset;
    }
}
