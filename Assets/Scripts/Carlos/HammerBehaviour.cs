using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBehaviour : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Order")
        {
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("ORDERR!!");
                GAME_MANAGER._GAME_MANAGER.Order();
                
            }

        }
        if (collision.gameObject.tag == "Guilty")
        {
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("GUILTY!!");
                //GAME_MANAGER._GAME_MANAGER.Order();
            }

        }
        if (collision.gameObject.tag == "Innocent")
        {
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("INNOCENT!!");
                //GAME_MANAGER._GAME_MANAGER.Order();
            }

        }
    }
}
