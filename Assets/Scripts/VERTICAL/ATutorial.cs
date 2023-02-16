using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ATutorial : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
