using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Camera
    public GameObject player;
    public GameObject cameraTarget;
    public Camera cam;
    float h;
    float v;

    public float hSpeed;
    public float vSpeed;
    #endregion
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region CameraMovement   
        if (GAME_MANAGER._GAME_MANAGER.isGamePaused == false)
        {
            this.transform.LookAt(cameraTarget.transform);
        }      
        #endregion






    }
}
