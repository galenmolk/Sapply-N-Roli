using System;
using UnityEngine;
using UnityEngine.InputSystem;
using BramblyMead;

namespace GGJ
{
    public class InputManager : Singleton<InputManager>
    {
        public static Action OnUpStart;
        public static Action OnDownStart;
        public static Action OnLeftStart;
        public static Action OnRightStart;

        public static Action OnUpStop;
        public static Action OnDownStop;
        public static Action OnLeftStop;
        public static Action OnRightStop;

        public static Action OnPauseMenuToggled;

        private DefaultControls inputActions;

        public void EnableInput()
        {
            inputActions.Enable();
        }

        public void DisableInput()
        {
            inputActions.Disable();
        }

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

        private void HandlePauseMenuToggled(InputAction.CallbackContext action)
        {
            OnPauseMenuToggled?.Invoke();
        }

        private void Awake()
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

            inputActions.Keyboard.TogglePause.performed += HandlePauseMenuToggled;

            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Keyboard.Up.performed -= HandleUpStart;
            inputActions.Keyboard.Down.performed -= HandleDownStart;
            inputActions.Keyboard.Left.performed -= HandleLeftStart;
            inputActions.Keyboard.Right.performed -= HandleRightStart;

            inputActions.Keyboard.Up.canceled -= HandleUpStop;
            inputActions.Keyboard.Down.canceled -= HandleDownStop;
            inputActions.Keyboard.Left.canceled -= HandleLeftStop;
            inputActions.Keyboard.Right.canceled -= HandleRightStop;

            inputActions.Keyboard.TogglePause.performed -= HandlePauseMenuToggled;

            inputActions.Disable();
        }
    }
}
