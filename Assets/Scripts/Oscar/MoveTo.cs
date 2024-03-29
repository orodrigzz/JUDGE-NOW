using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public MoveTo moveto;

    [SerializeField] private Vector3 targetPos;
    [SerializeField] private Vector3 judgalityTargetPos;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject judgalityTarget;
    [SerializeField] private GameObject cameraTarget;
    [SerializeField] private float speed = 0.6f;

    [SerializeField] private float secs;

    [SerializeField] private Animator animator;
    [SerializeField] private bool dead;
    [SerializeField] private bool isJudgality;
    [SerializeField] private bool canFall;

    private void Awake()
    {
        if (animator != null)
        {
            animator = GetComponent<Animator>();
        }

        if (target != null)
        {
            targetPos = target.transform.position;
        }

        if (judgalityTarget != null)
        {
            judgalityTargetPos = judgalityTarget.transform.position;
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

        if (moveto != null)
        {
            if (moveto.isJudgality)
            {
                canFall = true;
                animator.SetBool("isFalling", true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            if (GAME_MANAGER._GAME_MANAGER.decisionMode)
            {
                isJudgality = true; 
                speed = -50;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, judgalityTargetPos, Time.deltaTime * -speed);
                animator.SetBool("Judgalitydead", true);
                StartCoroutine(DesapearNPCs());
            }
            else
            {
                dead = true;
                speed = 0;
                animator.SetBool("dead", true);
                StartCoroutine(StopAnimation());
            }
        }
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(3);
        animator.SetBool("dead", false);
        dead = false;
        speed = 1;
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

            if (GAME_MANAGER._GAME_MANAGER.endDialogue == false && GAME_MANAGER._GAME_MANAGER.currentScene.name != "Tutorial")
            {
                GAME_MANAGER._GAME_MANAGER.initDialogue = true;
            }
            if (GAME_MANAGER._GAME_MANAGER.currentScene.name == "Tutorial")
            {
                GAME_MANAGER._GAME_MANAGER.tutorialStarted = true;
            }
            

            speed = 0f;
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("hasArrived", false);
            }
        }
    }
    IEnumerator DesapearNPCs()
    {
        yield return new WaitForSeconds(1);

        if(GAME_MANAGER._GAME_MANAGER.currentScene.name != "Tutorial")
        {
            GAME_MANAGER._GAME_MANAGER.SetCaseStatus(true);
            GAME_MANAGER._GAME_MANAGER.isDialoging = false;
            GAME_MANAGER._GAME_MANAGER.decisionMode = false;
        }
    }
}
