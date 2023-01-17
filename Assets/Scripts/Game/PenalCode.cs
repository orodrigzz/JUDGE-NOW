using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenalCode : MonoBehaviour
{
    public GameObject UI;
    public GameObject objeto;

    public Material transparente;
    public Material original;

    private void OnMouseDown()
    {
        UI.SetActive(true);
        Renderer rend = objeto.GetComponent<Renderer>();
        rend.material = transparente;
    }

    void Update()
    {
        if (UI.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(1))
            {
                UI.SetActive(false);
                Renderer rend = objeto.GetComponent<Renderer>();
                rend.material = original;
            }
        }
    }
}
