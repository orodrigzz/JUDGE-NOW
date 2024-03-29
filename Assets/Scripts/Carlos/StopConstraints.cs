using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopConstraints : MonoBehaviour
{
    Rigidbody rb;
    public bool freezedconstraints = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Table")
        {
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                freezedconstraints = true;
            }
        }
    }
}
