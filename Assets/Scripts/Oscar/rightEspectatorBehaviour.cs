using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightEspectatorBehaviour : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public ShootR shootR;

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
        if (shootR.rightShooterTargetTime <= 3)
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
