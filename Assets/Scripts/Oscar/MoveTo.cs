using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 0.6f;

    [SerializeField] private float secs;

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
