using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private void OnMouseDown()
    {
        REPUTATION_MANAGER._REPUTATION_MANAGER.Order();
    }
}
