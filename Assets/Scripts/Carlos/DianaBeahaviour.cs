using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaBeahaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Hammer")
        {
            Destroy(this.gameObject);
        }
    }
}
