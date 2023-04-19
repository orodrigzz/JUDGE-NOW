using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Door" || collision.gameObject.tag == "Atril")
        {
            StartCoroutine(WaitForDestroy(1));
        }
    }

    IEnumerator WaitForDestroy(float secs)
    {
        yield return new WaitForSeconds(secs);
        Destroy(this.gameObject);
    }
}
