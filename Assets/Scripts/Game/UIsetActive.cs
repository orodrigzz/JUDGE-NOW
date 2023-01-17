using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIsetActive : MonoBehaviour
{
    public GameObject UI;

    void Start()
    {
        UI.SetActive(false);
    }
}
