using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplainantBehaviour : MonoBehaviour
{
    //public GameObject UI;

    //void Start()
    //{
    //    UI.SetActive(false);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    UI.SetActive(true);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
