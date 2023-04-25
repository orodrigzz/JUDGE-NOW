using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraIntro : MonoBehaviour
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject cameraTarget;
    [SerializeField] private float speed = 0.6f;

    [SerializeField] private float secs;
    public GameObject UI;

    private void Awake()
    {
        UI.SetActive(false);

        if (target != null)
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
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * speed);

        if (transform.localPosition == targetPos)
        {
            speed = 0f;
            UI.SetActive(true);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Case4");
    }
}