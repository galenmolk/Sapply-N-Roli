//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/DefaultControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace GGJ
{
    public partial class @DefaultControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @DefaultControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultControls"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""887d4d9a-a1d9-4219-81c5-ccbe6550531c"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""26aa0993-6544-4322-a087-f6f24588a004"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""76797725-1b24-4087-8ff2-372243ddabd9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""e2a3f14c-8ba5-42c2-b85f-f7cb1c3963d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""6dba5f7b-6c5d-4f94-8686-fd87a4828b45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TogglePause"",
                    ""type"": ""Button"",
                    ""id"": ""f12fad7d-50dd-417b-bb4b-23c1080c679f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""07f566e8-4f7e-4f25-bc60-1eeb1a93fda7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db1570cb-c0ec-463f-895c-ed1bceb68e42"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86cbf9bb-d8e3-4d24-a4bc-2c04cc041be8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fb96a2f-4956-4875-9121-3e5befb01a19"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee4b4445-8b0a-46ba-8f28-bc65927230fe"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8ef6134-fcc3-4368-9e46-06a61b3754fe"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""840df5ee-a110-44df-b859-bc5090e85b99"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c5bed85-51fd-4770-bcc8-a33247e56eb7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""debf4ed5-4482-49f5-8e2c-2643cde68556"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TogglePause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Keyboard
            m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
            m_Keyboard_Up = m_Keyboard.FindAction("Up", throwIfNotFound: true);
            m_Keyboard_Down = m_Keyboard.FindAction("Down", throwIfNotFound: true);
            m_Keyboard_Left = m_Keyboard.FindAction("Left", throwIfNotFound: true);
            m_Keyboard_Right = m_Keyboard.FindAction("Right", throwIfNotFound: true);
            m_Keyboard_TogglePause = m_Keyboard.FindAction("TogglePause", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Keyboard
        private readonly InputActionMap m_Keyboard;
        private IKeyboardActions m_KeyboardActionsCallbackInterface;
        private readonly InputAction m_Keyboard_Up;
        private readonly InputAction m_Keyboard_Down;
        private readonly InputAction m_Keyboard_Left;
        private readonly InputAction m_Keyboard_Right;
        private readonly InputAction m_Keyboard_TogglePause;
        public struct KeyboardActions
        {
            private @DefaultControls m_Wrapper;
            public KeyboardActions(@DefaultControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Up => m_Wrapper.m_Keyboard_Up;
            public InputAction @Down => m_Wrapper.m_Keyboard_Down;
            public InputAction @Left => m_Wrapper.m_Keyboard_Left;
            public InputAction @Right => m_Wrapper.m_Keyboard_Right;
            public InputAction @TogglePause => m_Wrapper.m_Keyboard_TogglePause;
            public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
            public void SetCallbacks(IKeyboardActions instance)
            {
                if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
                {
                    @Up.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUp;
                    @Up.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUp;
                    @Up.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnUp;
                    @Down.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDown;
                    @Down.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDown;
                    @Down.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnDown;
                    @Left.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeft;
                    @Left.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeft;
                    @Left.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnLeft;
                    @Right.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRight;
                    @Right.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRight;
                    @Right.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnRight;
                    @TogglePause.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnTogglePause;
                    @TogglePause.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnTogglePause;
                    @TogglePause.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnTogglePause;
                }
                m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Up.started += instance.OnUp;
                    @Up.performed += instance.OnUp;
                    @Up.canceled += instance.OnUp;
                    @Down.started += instance.OnDown;
                    @Down.performed += instance.OnDown;
                    @Down.canceled += instance.OnDown;
                    @Left.started += instance.OnLeft;
                    @Left.performed += instance.OnLeft;
                    @Left.canceled += instance.OnLeft;
                    @Right.started += instance.OnRight;
                    @Right.performed += instance.OnRight;
                    @Right.canceled += instance.OnRight;
                    @TogglePause.started += instance.OnTogglePause;
                    @TogglePause.performed += instance.OnTogglePause;
                    @TogglePause.canceled += instance.OnTogglePause;
                }
            }
        }
        public KeyboardActions @Keyboard => new KeyboardActions(this);
        public interface IKeyboardActions
        {
            void OnUp(InputAction.CallbackContext context);
            void OnDown(InputAction.CallbackContext context);
            void OnLeft(InputAction.CallbackContext context);
            void OnRight(InputAction.CallbackContext context);
            void OnTogglePause(InputAction.CallbackContext context);
        }
    }
}
