using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeCanvas : MonoBehaviour
{
    public GameObject UI;

    private void OnMouseDown()
    {
        UI.SetActive(false); 
        Destroy(gameObject);
    }

}
