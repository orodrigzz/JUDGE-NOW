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
    [SerializeField] AudioSource Bonk;
    [SerializeField] AudioSource Interruptor;
    [SerializeField] AudioSource Ouch;

    private void Update()
    {
        rb = GetComponent<Rigidbody>();
        direction = -this.transform.right;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Order")
        {
            if(AudioMazo != null)
            {
                AudioMazo.Play();
            }
            
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

        if (collision.gameObject.tag == "Table")
        {
            AudioMazo.Play();
        }

        if (collision.gameObject.tag == "NPC")
        {
            Bonk.Play();
            Ouch.Play();
            //AudioMazo.Play();
        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Door")
        {
            //AudioMazo.Play();
            StartCoroutine(WaitForDestroy());
        }

        if (collision.gameObject.tag == "Apple" || collision.gameObject.tag == "Tomatoe" || collision.gameObject.tag == "Mobile")
        {
            Physics.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider>());
        }
        if (collision.gameObject.tag == "Table")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Switch")
        {
            Interruptor.Play();
            //AudioMazo.Play();
            StartCoroutine(WaitForDestroy());
            if (GAME_MANAGER._GAME_MANAGER.lightsOn == false)
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

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);   
    }
}
