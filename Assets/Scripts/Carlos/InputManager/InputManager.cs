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
    public Vector2 mouseDelta = Vector2.zero;
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
            input_Manager.Player.MousePosition.performed += MouseDelta;
                        
            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

   void Start()
   {
        Cursor.visible = false;
   }

   void Update()
   {
        InputSystem.Update();
   }

   public void LeftAxisValue(InputAction.CallbackContext context)
   {
        leftCameraAxis = context.ReadValue<Vector2>();
        //Debug.Log("Magnitude:" + leftCameraAxis.magnitude);
        //Debug.Log("Normalized: " + leftCameraAxis.normalized);

   }

   public void MouseDelta(InputAction.CallbackContext  context)
   {
        mouseDelta = context.ReadValue<Vector2>();               
   }

   public Vector2 GetDeltaMouse()
   {
       return this.mouseDelta;
   }
}
