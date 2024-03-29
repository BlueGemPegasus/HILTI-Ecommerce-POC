//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/Codes/InputSystem/PlayerInputs.inputactions
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

namespace H.Input
{
    public partial class @PlayerInputs : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""OnScreen"",
            ""id"": ""ac5a6fda-6421-4e64-a2d4-4aa93f6785a0"",
            ""actions"": [
                {
                    ""name"": ""Place"",
                    ""type"": ""Value"",
                    ""id"": ""bd2aeacc-1c6e-4f51-baec-c8a001655c29"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""5c874d18-9632-4c0f-9647-b8b3377c7fc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""95b754fa-010c-4dcf-9490-576f94608f85"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Phone"",
                    ""action"": ""Place"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c71a8219-e803-4fdf-b46b-67f70e81d368"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Phone"",
            ""bindingGroup"": ""Phone"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // OnScreen
            m_OnScreen = asset.FindActionMap("OnScreen", throwIfNotFound: true);
            m_OnScreen_Place = m_OnScreen.FindAction("Place", throwIfNotFound: true);
            m_OnScreen_Touch = m_OnScreen.FindAction("Touch", throwIfNotFound: true);
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

        // OnScreen
        private readonly InputActionMap m_OnScreen;
        private IOnScreenActions m_OnScreenActionsCallbackInterface;
        private readonly InputAction m_OnScreen_Place;
        private readonly InputAction m_OnScreen_Touch;
        public struct OnScreenActions
        {
            private @PlayerInputs m_Wrapper;
            public OnScreenActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Place => m_Wrapper.m_OnScreen_Place;
            public InputAction @Touch => m_Wrapper.m_OnScreen_Touch;
            public InputActionMap Get() { return m_Wrapper.m_OnScreen; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(OnScreenActions set) { return set.Get(); }
            public void SetCallbacks(IOnScreenActions instance)
            {
                if (m_Wrapper.m_OnScreenActionsCallbackInterface != null)
                {
                    @Place.started -= m_Wrapper.m_OnScreenActionsCallbackInterface.OnPlace;
                    @Place.performed -= m_Wrapper.m_OnScreenActionsCallbackInterface.OnPlace;
                    @Place.canceled -= m_Wrapper.m_OnScreenActionsCallbackInterface.OnPlace;
                    @Touch.started -= m_Wrapper.m_OnScreenActionsCallbackInterface.OnTouch;
                    @Touch.performed -= m_Wrapper.m_OnScreenActionsCallbackInterface.OnTouch;
                    @Touch.canceled -= m_Wrapper.m_OnScreenActionsCallbackInterface.OnTouch;
                }
                m_Wrapper.m_OnScreenActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Place.started += instance.OnPlace;
                    @Place.performed += instance.OnPlace;
                    @Place.canceled += instance.OnPlace;
                    @Touch.started += instance.OnTouch;
                    @Touch.performed += instance.OnTouch;
                    @Touch.canceled += instance.OnTouch;
                }
            }
        }
        public OnScreenActions @OnScreen => new OnScreenActions(this);
        private int m_PhoneSchemeIndex = -1;
        public InputControlScheme PhoneScheme
        {
            get
            {
                if (m_PhoneSchemeIndex == -1) m_PhoneSchemeIndex = asset.FindControlSchemeIndex("Phone");
                return asset.controlSchemes[m_PhoneSchemeIndex];
            }
        }
        public interface IOnScreenActions
        {
            void OnPlace(InputAction.CallbackContext context);
            void OnTouch(InputAction.CallbackContext context);
        }
    }
}
