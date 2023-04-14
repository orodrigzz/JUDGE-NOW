using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject cameraTarget;
    [SerializeField] private float speed = 0.6f;

    [SerializeField] private float secs;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (animator != null)
        {
            animator = GetComponent<Animator>();
        }

        if ( target != null)
        {
            targetPos = target.transform.position;
        }

        if (cameraTarget != null)
        {
            targetPos = cameraTarget.transform.position;
        }
    }

    void Update()
    {
        StartCoroutine(Wait());

        if (cameraTarget != null && targetPos == cameraTarget.transform.position && this.transform.position == targetPos)
        {
            Vector3 newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(secs);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * speed);

        if (transform.localPosition == targetPos)
        {
            if (animator != null)
            {
                animator.SetBool("hasArrived", true);
            }

            if (GAME_MANAGER._GAME_MANAGER.endDialogue == false)
            {
                GAME_MANAGER._GAME_MANAGER.initDialogue = true;
            }
            speed = 0f;
        }
    }
}
