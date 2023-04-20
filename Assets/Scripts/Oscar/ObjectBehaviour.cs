using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField] AudioSource Bonk;
    [SerializeField] AudioSource Interruptor;

    [SerializeField] AudioSource Ouch;
    [SerializeField] AudioSource OuchWoman;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NPC" || collision.gameObject.tag == "Testigo_M")
        {
            Bonk.Play();
            Ouch.Play();
            StartCoroutine(WaitForDestroy(1.5f));
        }

        if (collision.gameObject.tag == "NPC_W" || collision.gameObject.tag == "Testigo_W")
        {
            Bonk.Play();
            OuchWoman.Play();
            StartCoroutine(WaitForDestroy(1.5f));
        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Door" || collision.gameObject.tag == "Atril")
        {
            StartCoroutine(WaitForDestroy(1.5f));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Switch")
        {
            Interruptor.Play();
        }
    }

    IEnumerator WaitForDestroy(float secs)
    {
        yield return new WaitForSeconds(secs);
        Destroy(this.gameObject);
    }
}
