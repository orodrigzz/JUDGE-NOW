using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Camera
    public GameObject player;

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
        player.transform.rotation = Quaternion.identity;
        h += InputManager._INPUT_MANAGER.leftCameraAxis.y * hSpeed * Time.deltaTime;
        h = Mathf.Clamp(h, -89f, 89f);
        v += InputManager._INPUT_MANAGER.leftCameraAxis.x * vSpeed * Time.deltaTime;
        Quaternion TO_DELETE_V2_Version_Buena = Quaternion.Euler(-h, -v, 0f);
        transform.rotation = TO_DELETE_V2_Version_Buena;  


        //player.transform.Rotate(-h, -v, 0);

        if(h <=0 || v <= 0)
        {
            player.transform.Rotate(0, 0, 0);
        }
        
    }
}
