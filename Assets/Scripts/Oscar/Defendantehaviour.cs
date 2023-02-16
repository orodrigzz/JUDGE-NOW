using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defendantehaviour : MonoBehaviour
{
    public GameObject UI;
    void Start()
    {
        UI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        UI.SetActive(true);
    }
}
