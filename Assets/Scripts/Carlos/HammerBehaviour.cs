using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HammerBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 direction;

    [SerializeField] AudioSource AudioMazo;

    private void Update()
    {
        rb = GetComponent<Rigidbody>();
        direction = -this.transform.right;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Order")
        {
            AudioMazo.Play();
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                GAME_MANAGER._GAME_MANAGER.Order();
            }
        }

        if (collision.gameObject.tag == "Guilty")
        {
            AudioMazo.Play();
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("GUILTY!!");
                GAME_MANAGER._GAME_MANAGER.goodCase();
                SceneManager.LoadScene("CaseOver");
            }
        }

        if (collision.gameObject.tag == "Innocent")
        {
            AudioMazo.Play();
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("INNOCENT!!");
                GAME_MANAGER._GAME_MANAGER.badCase();
                SceneManager.LoadScene("CaseOver");
            }
        }

        if (collision.gameObject.tag == "Table" || collision.gameObject.name == "LightBtnn" || collision.gameObject.name == "NPC")
        {
            AudioMazo.Play();
        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Door")
        {
            AudioMazo.Play();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Switch")
        {
            if(GAME_MANAGER._GAME_MANAGER.lightsOn == false)
            {
                GAME_MANAGER._GAME_MANAGER.TurnUpLights();
                GAME_MANAGER._GAME_MANAGER.lightsOn = true;
            }else
            {
                GAME_MANAGER._GAME_MANAGER.lightsOn = false;
            }
        }
    }

    public void ThrowHammer()
    {
        if(rb != null)
        {
            rb.AddForce(direction * speed);
        }
    }
}
