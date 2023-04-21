using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TomatoeCanvas : MonoBehaviour
{
    public GameObject TomatoeUI;
    public AudioSource tomatoe;

    private void Start()
    {
        TomatoeUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tomatoe")
        {
            tomatoe.Play();
            TomatoeUI.SetActive(true);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(7);
        TomatoeUI.SetActive(false);
    }

}
