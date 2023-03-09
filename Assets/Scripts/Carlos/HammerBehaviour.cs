using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBehaviour : MonoBehaviour
{

    [SerializeField] public bool mazazo = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Order")
        {
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                mazazo = true;
                GAME_MANAGER._GAME_MANAGER.Order();
            }
        }

        if (collision.gameObject.tag == "Guilty")
        {
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                mazazo = true;
                Debug.Log("GUILTY!!");
                GAME_MANAGER._GAME_MANAGER.goodCase();
            }
        }

        if (collision.gameObject.tag == "Innocent")
        {
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                mazazo = true;
                Debug.Log("INNOCENT!!");
                GAME_MANAGER._GAME_MANAGER.badCase();
            }
        }

        if (collision.gameObject.tag == "Table")
        {
            mazazo = true;
        }

        if (collision.gameObject.tag == "Ground")
        {
            mazazo = true; 
            Destroy(this.gameObject);
        }
    }
}
