using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeConstraints : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Apple
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
    }
}
