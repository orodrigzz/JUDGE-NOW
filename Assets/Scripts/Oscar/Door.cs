using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 targetPos;
    public float speed;

    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * speed);
    }
}
