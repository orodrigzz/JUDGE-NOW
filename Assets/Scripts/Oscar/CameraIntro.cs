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
        if (UI != null)
        {
            UI.SetActive(false);
        }

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

            if (UI != null)
            {
                UI.SetActive(true);
            }

            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        if (GAME_MANAGER._GAME_MANAGER.currentScene.name == "Scenario2")
        {
            SceneManager.LoadScene("Day2");
        }
        if (GAME_MANAGER._GAME_MANAGER.currentScene.name == "Scenario3")
        {
            SceneManager.LoadScene("Day3");
        }
    }

}