using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    float rotationX;
    float rotationY;
    public GameObject root;
    Vector2 mouseDelta;
    [SerializeField] private bool fixy = false;
    [SerializeField] private float rotationxmax = 89;

    // Update is called once per frame
    void Update()
    {
        if (GAME_MANAGER._GAME_MANAGER.isGamePaused == false)
        {
            mouseDelta = InputManager._INPUT_MANAGER.GetDeltaMouse();
            if (!fixy)
            {
                rotationX += mouseDelta.y;
                rotationX = Mathf.Clamp(rotationX, -rotationxmax, rotationxmax);
            }
            else
            {
                if (mouseDelta.y > 0)
                {
                    rotationX += mouseDelta.y;
                    rotationX = Mathf.Clamp(rotationX, -rotationxmax, rotationxmax);
                }
            }
            rotationY += mouseDelta.x;
            rotationY = Mathf.Clamp(rotationY, 1, 160f);
            
            if (mouseDelta.x != 0 || mouseDelta.y != 0)
            {
                root.transform.rotation = Quaternion.identity;
                Quaternion rot = Quaternion.Euler(0, rotationY, -rotationX);
                root.transform.rotation = rot;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        fixy = true;
        Debug.LogError("Enter");
    }

    private void OnTriggerExit(Collider other)
    {
        fixy = false;
        Debug.LogError("Exit");
    }
}
