using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    public Vector3[] rayOrigins;
    public LayerMask layer;
    public GameObject parent;
    public Rigidbody itemPicked;

    private void Update()
    {
            foreach (Vector3 origin in rayOrigins)
            {
                Ray ray = new Ray(transform.position + origin, transform.forward);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit,10f, layer))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        itemPicked = hit.rigidbody;
                        itemPicked.transform.localScale = transform.parent.localScale;
                        itemPicked.transform.rotation = transform.parent.rotation;
                        //itemPicked.transform.localScale = new Vector3(1,1,1);
                         itemPicked.transform.SetParent(parent.transform);                                        
                        if (itemPicked != null)
                        {   
                            itemPicked.useGravity = false;
                        }
                    }
            }
            else
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("Adoptado");
                    if(itemPicked != null)
                    {
                        itemPicked.transform.SetParent(null);
                        itemPicked.useGravity = true;
                    }
                        itemPicked = null;
                }
            }
           
                Debug.DrawRay(transform.position + origin, transform.forward * 100, Color.green);
            }
        
    }
}
