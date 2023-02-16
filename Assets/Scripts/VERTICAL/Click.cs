using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
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

    private void OnMouseUp()
    {
        UI.SetActive(false);
        Renderer rend = objeto.GetComponent<Renderer>();
        rend.material = original;
    }

}
