using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TomatoeCanvas : MonoBehaviour
{
    public GameObject TomatoeUI;

    private void Start()
    {
        TomatoeUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tomatoe")
        {
            //Reproducir audio tomatazo
            TomatoeUI.SetActive(true);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        TomatoeUI.SetActive(false);
    }

}
