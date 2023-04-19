using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileBehaviour : MonoBehaviour
{

    private void Update()
    {
        Destroy(this, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           GAME_MANAGER._GAME_MANAGER.courtReputation -= 0.02f;
            GAME_MANAGER._GAME_MANAGER.townReputation -= 0.02f;
            Debug.Log("Hit");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

}