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
    [SerializeField] AudioSource golpeMesa;

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
            if (AudioMazo != null)
            {
                AudioMazo.Play();
            }

            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("GUILTY!!");
                StartCoroutine(WaitForCaseOver());
            }
        }

        if (collision.gameObject.tag == "Innocent")
        {
            if (AudioMazo != null)
            {
                AudioMazo.Play();
            }

            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("INNOCENT!!");
                StartCoroutine(WaitForCaseOver());
            }
        }

        //if (collision.gameObject.tag == "Table")
        //{
        //    if (golpeMesa != null)
        //    {
        //        golpeMesa.Play();
        //    }
        //}

        if (collision.gameObject.tag == "NPC")
        {
            Bonk.Play();
            Ouch.Play();
            StartCoroutine(WaitForDestroy(1.5f));
        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Door" || collision.gameObject.tag == "Atril")
        {
            //AudioMazo.Play();
            StartCoroutine(WaitForDestroy(1));
        }

        if (collision.gameObject.tag == "Apple" || collision.gameObject.tag == "Tomatoe" || collision.gameObject.tag == "Mobile")
        {
            Physics.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider>());
        }

        if (collision.gameObject.tag == "Table")
        {
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Switch")
        {
            Interruptor.Play();
            StartCoroutine(WaitForDestroy(1));
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

    IEnumerator WaitForDestroy(float secs)
    {
        yield return new WaitForSeconds(secs);
        Destroy(this.gameObject);   
    }

    IEnumerator WaitForCaseOver()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("CaseOver");
    }
}
