using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileBehaviour : MonoBehaviour
{
    public AUDIO_MANAGER AUDIO_MANAGER;

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Table")
        //{
        //    AUDIO_MANAGER.playRogira = false;
        //}

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
