using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Vector3 targetPos;
    public GameObject target;
    public float speed = 0.2f;

    private void Awake()
    {
        if ( target != null)
        {
            targetPos = target.transform.position;
        }
    }

    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * speed);
    
        if (transform.localPosition == targetPos)
        {
            
            speed = 0f;
            if(GAME_MANAGER._GAME_MANAGER.endDialogue == false)
            {
                GAME_MANAGER._GAME_MANAGER.initDialogue = true;
            }
            
        }
    }
}
