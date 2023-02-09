using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    public Vector3[] rayOrigins;
    public LayerMask layer;

    private void Update()
    {
        foreach(Vector3 origin in rayOrigins)
        {
            Ray ray = new Ray(transform.position + origin, transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit,10f, layer))
            {
                if (Input.GetMouseButton(0))
                {                                  
                    hit.transform.position = transform.position;
                    hit.transform.rotation = transform.rotation;
                    Rigidbody rigidbody = hit.transform.GetComponent<Rigidbody>();
                    if (rigidbody != null)
                    {
                        rigidbody.useGravity = false;
                    }
                }
            }
           
            Debug.DrawRay(transform.position + origin, transform.forward * 100, Color.green);
        }
    }
}
