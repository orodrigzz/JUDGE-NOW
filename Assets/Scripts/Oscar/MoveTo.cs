using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Vector3 targetPos;
    public GameObject target;
    public float speed = 0.6f;

    public int secs;

    private void Awake()
    {
        if ( target != null)
        {
            targetPos = target.transform.position;
        }


    }

    void Update()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(secs);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * speed);

        if (transform.localPosition == targetPos)
        {
            if (GAME_MANAGER._GAME_MANAGER.endDialogue == false)
            {
                GAME_MANAGER._GAME_MANAGER.initDialogue = true;
            }
            speed = 0f;
        }
    }
}
