using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileBehaviour : MonoBehaviour
{
    public SphereCollider colliderTomatoe;
    private void Update()
    {
        Destroy(this, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           GAME_MANAGER._GAME_MANAGER.noise += 0.02f;
            Debug.Log("Hit");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.layer == 7 ||collision.gameObject.layer == 11 || collision.gameObject.layer == 10)
        {
            
                Physics.IgnoreCollision(collision.collider,  colliderTomatoe);
            
        }
    }
    
   

}