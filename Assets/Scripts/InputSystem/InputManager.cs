using System;
using System.Linq;

using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

using Vector2 = UnityEngine.Vector2;


namespace InputSystem
{
    public class InputManager : MonoBehaviour{
        
        public UnityEvent<bool> leftButtonChangedEvent;
       public UnityEvent<bool> rightButtonChangedEvent;
       public UnityEvent<bool> middleButtonChangedEvent;
       public UnityEvent<Vector2> mouseMovementEvent;
       

       public UnityEvent<Vector2> mouseDeltaStoppedEvent;
       public UnityEvent<Vector2> mouseDeltaMovedEvent;
       
       public UnityEvent<Vector2> scrollMovementEvent;
       
       private InputControls controls;

       private void Awake()
       {
           controls = new InputControls();
           controls.Enable();
           
           controls.Player.RightClick.performed += OnRightButtonChanged;
           controls.Player.RightClick.canceled += OnRightButtonChanged;
           
           controls.Player.LeftClick.performed += OnLeftButtonChanged;
           controls.Player.LeftClick.canceled += OnLeftButtonChanged;

           controls.Player.MiddleClick.performed += OnLeftMiddleChanged;
           controls.Player.MiddleClick.canceled += OnLeftMiddleChanged;
           
           controls.Player.MousePos.performed += OnMouseMovement;
           

           
           controls.Player.MouseDelta.performed += OnMouseDelta;
           controls.Player.MouseDelta.canceled += OnMouseDelta;
           
           
           controls.Player.Scroll.performed += OnScrollMovement;
       }

       private void OnLeftButtonChanged(InputAction.CallbackContext context)
       {
           if (leftButtonChangedEvent == null) return;
           InputActionPhase phase = context.phase;
           if (phase == InputActionPhase.Performed)
           {
               leftButtonChangedEvent.Invoke(true);
           }
           else if (phase == InputActionPhase.Canceled)
           {
               leftButtonChangedEvent.Invoke(false);
           }
       }

       private void OnRightButtonChanged(InputAction.CallbackContext context)
       {
           if (rightButtonChangedEvent == null) return;
           rightButtonChangedEvent.Invoke(true);
           InputActionPhase phase = context.phase;
           if (phase == InputActionPhase.Performed)
           {
               rightButtonChangedEvent.Invoke(true);
           }
           else if (phase == InputActionPhase.Canceled)
           {
               rightButtonChangedEvent.Invoke(false);
           }
       }

       private void OnLeftMiddleChanged(InputAction.CallbackContext context)
       {
           if (middleButtonChangedEvent == null) return;
           middleButtonChangedEvent.Invoke(true);
           InputActionPhase phase = context.phase;
           if (phase == InputActionPhase.Performed)
           {
               middleButtonChangedEvent.Invoke(true);
           }
           else if (phase == InputActionPhase.Canceled)
           {
               middleButtonChangedEvent.Invoke(false);
           }
       }

       private void OnMouseMovement(InputAction.CallbackContext context)
       {
           if(mouseMovementEvent == null) return;
           mouseMovementEvent.Invoke(context.ReadValue<Vector2>());
       }



       private void OnMouseDelta(InputAction.CallbackContext context)
       {
           if(context.performed)
               mouseDeltaMovedEvent.Invoke(context.ReadValue<Vector2>());

           if (context.canceled)
           {
               mouseDeltaStoppedEvent.Invoke(context.ReadValue<Vector2>());
           }
               
       }


       private void OnScrollMovement(InputAction.CallbackContext context)
       {
           if(scrollMovementEvent == null) return;
           scrollMovementEvent.Invoke(context.ReadValue<Vector2>());
       }
   }
}