using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GGJ
{
    public class InputManager : MonoBehaviour
    {
        public static Action OnUpStart;
        public static Action OnDownStart;
        public static Action OnLeftStart;
        public static Action OnRightStart;

        public static Action OnUpStop;
        public static Action OnDownStop;
        public static Action OnLeftStop;
        public static Action OnRightStop;

        private DefaultControls inputActions;

        private void HandleUpStart(InputAction.CallbackContext action)
        {
            OnUpStart?.Invoke();
        }

        private void HandleDownStart(InputAction.CallbackContext action)
        {
            OnDownStart?.Invoke();
        }

        private void HandleLeftStart(InputAction.CallbackContext action)
        {
            OnLeftStart?.Invoke();
        }

        private void HandleRightStart(InputAction.CallbackContext action)
        {
            OnRightStart?.Invoke();
        }

        private void HandleUpStop(InputAction.CallbackContext action)
        {
            Debug.Log("Cancelled Up");
            OnUpStop?.Invoke();
        }

        private void HandleDownStop(InputAction.CallbackContext action)
        {
            OnDownStop?.Invoke();
        }

        private void HandleLeftStop(InputAction.CallbackContext action)
        {
            OnLeftStop?.Invoke();
        }

        private void HandleRightStop(InputAction.CallbackContext action)
        {
            OnRightStop?.Invoke();
        }

        private void Start()
        {
            inputActions = new DefaultControls();

            inputActions.Keyboard.Up.performed += HandleUpStart;
            inputActions.Keyboard.Down.performed += HandleDownStart;
            inputActions.Keyboard.Left.performed += HandleLeftStart;
            inputActions.Keyboard.Right.performed += HandleRightStart;

            inputActions.Keyboard.Up.canceled += HandleUpStop;
            inputActions.Keyboard.Down.canceled += HandleDownStop;
            inputActions.Keyboard.Left.canceled += HandleLeftStop;
            inputActions.Keyboard.Right.canceled += HandleRightStop;

            inputActions.Enable();
        }

        private void OnDestroy()
        {
            inputActions.Keyboard.Up.performed -= HandleUpStart;
            inputActions.Keyboard.Down.performed -= HandleDownStart;
            inputActions.Keyboard.Left.performed -= HandleLeftStart;
            inputActions.Keyboard.Right.performed -= HandleRightStart;

            inputActions.Keyboard.Up.canceled -= HandleUpStop;
            inputActions.Keyboard.Down.canceled -= HandleDownStop;
            inputActions.Keyboard.Left.canceled -= HandleLeftStop;
            inputActions.Keyboard.Right.canceled -= HandleRightStop;
            inputActions.Disable();
        }
    }
}
