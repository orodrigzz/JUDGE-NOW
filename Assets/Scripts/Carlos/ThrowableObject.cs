using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 direction;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        rb = GetComponent<Rigidbody>();
        direction = -this.transform.right;
        
    }

    public void Throw()
    {
        if (rb != null)
        {
            rb.AddForce(direction * speed * -1);
        }
    }
}
