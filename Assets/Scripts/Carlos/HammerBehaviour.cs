using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBehaviour : MonoBehaviour
{

    [SerializeField] private float hammerHealth = 10;
    [SerializeField] private GameObject hammer;
    [SerializeField] private GameObject spawnPos;

    private void Update()
    {
        if (hammerHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Order")
        {
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("ORDERR!!");
                GAME_MANAGER._GAME_MANAGER.Order();
                hammerHealth--;
            }
            hammerHealth--;
        }

        if (collision.gameObject.tag == "Guilty")
        {
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("GUILTY!!");
                GAME_MANAGER._GAME_MANAGER.goodCase();
                hammerHealth--;
            }
            hammerHealth--;
        }

        if (collision.gameObject.tag == "Innocent")
        {
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("INNOCENT!!");
                GAME_MANAGER._GAME_MANAGER.badCase();
                hammerHealth--;
            }
            hammerHealth--;
        }

        if (collision.gameObject.tag == "Table")
        {
            hammerHealth--;
        }

        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(hammer, spawnPos.transform);
            //Destroy(this.gameObject);
        }
    }
}
