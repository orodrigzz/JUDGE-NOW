using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HammerBehaviour : MonoBehaviour
{

    [SerializeField] public bool mazazo = false;
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 direction;

    private void Update()
    {
        rb = GetComponent<Rigidbody>();
        direction = -this.transform.right;
    }

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
            mazazo = true;
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("GUILTY!!");
                GAME_MANAGER._GAME_MANAGER.goodCase();
                SceneManager.LoadScene("CaseOver");
            }
        }

        if (collision.gameObject.tag == "Innocent")
        {
            mazazo = true;
            if (GAME_MANAGER._GAME_MANAGER.isPicked)
            {
                Debug.Log("INNOCENT!!");
                GAME_MANAGER._GAME_MANAGER.badCase();
                SceneManager.LoadScene("CaseOver");
            }
        }

        if (collision.gameObject.tag == "Table")
        {
            mazazo = true;
        }

        if (collision.gameObject.name == "LightBtnn")
        {
            mazazo = true;
        }

        if (collision.gameObject.tag == "Ground")
        {
            mazazo = true; 
            Destroy(this.gameObject);
        }
    }

    public void ThrowHammer()
    {
        if(rb != null)
        {
            rb.AddForce(direction * speed);
        }
    }
}
