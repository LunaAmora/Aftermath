//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/Scripts/UnityAssets/GameInput.inputactions
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

namespace Aftermath
{
    public partial class @GameInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Battle"",
            ""id"": ""49f125b7-bd49-4434-978a-6b74e0fbcb06"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6259f44f-5528-43ec-9fa3-78e4d8565dc1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MousePos"",
                    ""type"": ""Value"",
                    ""id"": ""5c138215-3a65-4c35-9ddb-aef6c836ea8d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""ef5d995c-5f52-4efb-9918-b817b2aadca9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""4889fcd0-f1fd-4e87-bf98-9a70f624e473"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""65af0836-4dc6-4722-965e-e7ac95f9c1ff"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5d6a6b25-306d-406a-acc0-daf94ec95979"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""27b29254-2507-4e43-9d97-90ecd02d6172"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5ce50d18-1479-4e65-bfa2-650b3d1b9d68"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""97efaa5f-66f9-454b-817a-85af3328173a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e63c1ad5-1cea-4f5e-9b22-fa75e32c33f4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90c9f7d4-cae3-4d08-95d4-74151d7cf4a9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a817115e-5369-4fa2-9a8f-3fc798ffebcc"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Battle
            m_Battle = asset.FindActionMap("Battle", throwIfNotFound: true);
            m_Battle_Move = m_Battle.FindAction("Move", throwIfNotFound: true);
            m_Battle_MousePos = m_Battle.FindAction("MousePos", throwIfNotFound: true);
            m_Battle_Click = m_Battle.FindAction("Click", throwIfNotFound: true);
            m_Battle_LeftClick = m_Battle.FindAction("LeftClick", throwIfNotFound: true);
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

        // Battle
        private readonly InputActionMap m_Battle;
        private IBattleActions m_BattleActionsCallbackInterface;
        private readonly InputAction m_Battle_Move;
        private readonly InputAction m_Battle_MousePos;
        private readonly InputAction m_Battle_Click;
        private readonly InputAction m_Battle_LeftClick;
        public struct BattleActions
        {
            private @GameInput m_Wrapper;
            public BattleActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Battle_Move;
            public InputAction @MousePos => m_Wrapper.m_Battle_MousePos;
            public InputAction @Click => m_Wrapper.m_Battle_Click;
            public InputAction @LeftClick => m_Wrapper.m_Battle_LeftClick;
            public InputActionMap Get() { return m_Wrapper.m_Battle; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(BattleActions set) { return set.Get(); }
            public void SetCallbacks(IBattleActions instance)
            {
                if (m_Wrapper.m_BattleActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnMove;
                    @MousePos.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnMousePos;
                    @MousePos.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnMousePos;
                    @MousePos.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnMousePos;
                    @Click.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnClick;
                    @Click.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnClick;
                    @Click.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnClick;
                    @LeftClick.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnLeftClick;
                    @LeftClick.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnLeftClick;
                    @LeftClick.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnLeftClick;
                }
                m_Wrapper.m_BattleActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @MousePos.started += instance.OnMousePos;
                    @MousePos.performed += instance.OnMousePos;
                    @MousePos.canceled += instance.OnMousePos;
                    @Click.started += instance.OnClick;
                    @Click.performed += instance.OnClick;
                    @Click.canceled += instance.OnClick;
                    @LeftClick.started += instance.OnLeftClick;
                    @LeftClick.performed += instance.OnLeftClick;
                    @LeftClick.canceled += instance.OnLeftClick;
                }
            }
        }
        public BattleActions @Battle => new BattleActions(this);
        public interface IBattleActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnMousePos(InputAction.CallbackContext context);
            void OnClick(InputAction.CallbackContext context);
            void OnLeftClick(InputAction.CallbackContext context);
        }
    }
}
