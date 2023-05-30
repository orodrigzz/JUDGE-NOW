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

        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Apple" || collision.gameObject.tag == "Tomatoe" || collision.gameObject.tag == "Mobile" || collision.gameObject.tag == "Rules1" || collision.gameObject.tag == "Rules2" || collision.gameObject.tag == "Rules3" || collision.gameObject.tag == "Hammer")
        {
            Physics.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider>());
        }
        if (collision.gameObject.tag == "Table")
        {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
   
}
