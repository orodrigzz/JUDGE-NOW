using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftEspectatorBehaviour : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Shoot shoot;

    private void Awake()
    {
        if (animator != null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot.leftShooterTargetTime <= 3)
        {
            if (animator != null)
            {
                animator.SetBool("StandUp", true);
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("StandUp", false);
    }
}

