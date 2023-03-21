using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePause : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
