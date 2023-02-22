using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private void OnMouseDown()
    {
        GAME_MANAGER._GAME_MANAGER.Order();
    }
}
