using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Manager
    public static InputManager _INPUT_MANAGER;
    private Input_Manager input_Manager;
    #endregion
    #region Camera
    public Vector2 leftCameraAxis = Vector2.zero;
    #endregion
    #region Arm
    public Vector2 mousePos = Vector2.zero;
    #endregion

    private void Awake()
    {
        if(_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            input_Manager = new Input_Manager();
            input_Manager.Player.Enable();
            input_Manager.Player.CameraMovement.performed += LeftAxisValue;
                        
            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputSystem.Update();
    }
   public void LeftAxisValue(InputAction.CallbackContext context)
   {
        leftCameraAxis = context.ReadValue<Vector2>();
        Debug.Log("Magnitude:" + leftCameraAxis.magnitude);
        Debug.Log("Normalized: " + leftCameraAxis.normalized);

   }
   public void MousePositionValue(InputAction.CallbackContext context)
   {
        mousePos = context.ReadValue<Vector2>();
        Debug.Log("Magnitude: " + mousePos.magnitude);
        Debug.Log("Normalized: " + mousePos.normalized);
   }
    
}
