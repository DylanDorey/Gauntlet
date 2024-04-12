//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scriptable Objects/WizardInput.inputactions
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

public partial class @WizardInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @WizardInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""WizardInput"",
    ""maps"": [
        {
            ""name"": ""Wizard"",
            ""id"": ""a931d4a3-2e30-42d1-9eb6-7005d6fbc5b3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""47810e5c-0aa0-4a63-aa17-26c711a297b4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LookUp"",
                    ""type"": ""Button"",
                    ""id"": ""5ec23270-50d9-465e-b48b-02e1dc884743"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookDown"",
                    ""type"": ""Button"",
                    ""id"": ""2a651d5e-c7f4-4fa5-bfc1-f07d00e40ae3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookLeft"",
                    ""type"": ""Button"",
                    ""id"": ""bb5e5089-0e58-40cb-b4aa-56076a3cb198"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookRight"",
                    ""type"": ""Button"",
                    ""id"": ""1478ad4d-a54c-46ab-8a51-b455992288fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""1b2b5dbc-2077-4afa-b477-3c0d1f93bd50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ac5a69a6-5ec5-473c-b783-27aa4b2da310"",
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
                    ""id"": ""467e2d08-0ec7-4114-b884-e1d2f63d1d75"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""30b1d756-9685-4da6-afcb-dbb4caa2e7f1"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3967634b-2326-436b-b0a7-b54c5872c947"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""605265de-50cf-49c4-907b-4a523636f478"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""19157f6b-b4c2-4621-87fe-f7281257c88b"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea7fcda3-a4bc-44d7-bc78-655b26d52b5d"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8447c5d-144f-4e95-bcfa-55dc550120af"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1734217-76f0-408e-a3d6-0fbf1d97adcc"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27679899-618d-4979-975d-76841937e0f5"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Wizard
        m_Wizard = asset.FindActionMap("Wizard", throwIfNotFound: true);
        m_Wizard_Move = m_Wizard.FindAction("Move", throwIfNotFound: true);
        m_Wizard_LookUp = m_Wizard.FindAction("LookUp", throwIfNotFound: true);
        m_Wizard_LookDown = m_Wizard.FindAction("LookDown", throwIfNotFound: true);
        m_Wizard_LookLeft = m_Wizard.FindAction("LookLeft", throwIfNotFound: true);
        m_Wizard_LookRight = m_Wizard.FindAction("LookRight", throwIfNotFound: true);
        m_Wizard_Shoot = m_Wizard.FindAction("Shoot", throwIfNotFound: true);
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

    // Wizard
    private readonly InputActionMap m_Wizard;
    private List<IWizardActions> m_WizardActionsCallbackInterfaces = new List<IWizardActions>();
    private readonly InputAction m_Wizard_Move;
    private readonly InputAction m_Wizard_LookUp;
    private readonly InputAction m_Wizard_LookDown;
    private readonly InputAction m_Wizard_LookLeft;
    private readonly InputAction m_Wizard_LookRight;
    private readonly InputAction m_Wizard_Shoot;
    public struct WizardActions
    {
        private @WizardInput m_Wrapper;
        public WizardActions(@WizardInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Wizard_Move;
        public InputAction @LookUp => m_Wrapper.m_Wizard_LookUp;
        public InputAction @LookDown => m_Wrapper.m_Wizard_LookDown;
        public InputAction @LookLeft => m_Wrapper.m_Wizard_LookLeft;
        public InputAction @LookRight => m_Wrapper.m_Wizard_LookRight;
        public InputAction @Shoot => m_Wrapper.m_Wizard_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Wizard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WizardActions set) { return set.Get(); }
        public void AddCallbacks(IWizardActions instance)
        {
            if (instance == null || m_Wrapper.m_WizardActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WizardActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @LookUp.started += instance.OnLookUp;
            @LookUp.performed += instance.OnLookUp;
            @LookUp.canceled += instance.OnLookUp;
            @LookDown.started += instance.OnLookDown;
            @LookDown.performed += instance.OnLookDown;
            @LookDown.canceled += instance.OnLookDown;
            @LookLeft.started += instance.OnLookLeft;
            @LookLeft.performed += instance.OnLookLeft;
            @LookLeft.canceled += instance.OnLookLeft;
            @LookRight.started += instance.OnLookRight;
            @LookRight.performed += instance.OnLookRight;
            @LookRight.canceled += instance.OnLookRight;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IWizardActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @LookUp.started -= instance.OnLookUp;
            @LookUp.performed -= instance.OnLookUp;
            @LookUp.canceled -= instance.OnLookUp;
            @LookDown.started -= instance.OnLookDown;
            @LookDown.performed -= instance.OnLookDown;
            @LookDown.canceled -= instance.OnLookDown;
            @LookLeft.started -= instance.OnLookLeft;
            @LookLeft.performed -= instance.OnLookLeft;
            @LookLeft.canceled -= instance.OnLookLeft;
            @LookRight.started -= instance.OnLookRight;
            @LookRight.performed -= instance.OnLookRight;
            @LookRight.canceled -= instance.OnLookRight;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IWizardActions instance)
        {
            if (m_Wrapper.m_WizardActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWizardActions instance)
        {
            foreach (var item in m_Wrapper.m_WizardActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WizardActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WizardActions @Wizard => new WizardActions(this);
    public interface IWizardActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLookUp(InputAction.CallbackContext context);
        void OnLookDown(InputAction.CallbackContext context);
        void OnLookLeft(InputAction.CallbackContext context);
        void OnLookRight(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
