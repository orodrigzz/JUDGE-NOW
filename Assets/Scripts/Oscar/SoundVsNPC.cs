using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVsNPC : MonoBehaviour
{
    [SerializeField] AudioSource Bonk;
    [SerializeField] AudioSource Interruptor;

    [SerializeField] AudioSource Ouch;
    [SerializeField] AudioSource OuchWoman;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Bonk.Play();
            Ouch.Play();
            StartCoroutine(WaitForDestroy(1.5f));
        }

        if (collision.gameObject.tag == "NPC_W")
        {
            Bonk.Play();
            OuchWoman.Play();
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
