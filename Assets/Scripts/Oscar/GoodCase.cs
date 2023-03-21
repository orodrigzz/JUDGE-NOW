using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCase : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            GAME_MANAGER._GAME_MANAGER.goodCase();
        }
    }
}
