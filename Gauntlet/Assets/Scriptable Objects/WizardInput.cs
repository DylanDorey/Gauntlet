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
            ""id"": ""c50280be-a27a-4b76-9edb-5b2125af6d4b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e3a77a97-f724-43ff-b075-52a9c2139c0c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""4ca9540c-7948-41f2-8409-1ecbcbd241ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""cdaeee26-bef9-4437-9d5b-29111f9c3b80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Use Potion"",
                    ""type"": ""Button"",
                    ""id"": ""7b05c42e-d300-42a2-997f-afcff2942b8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""964de7b0-aa8a-48b9-a5d9-13025239e8cf"",
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
                    ""id"": ""b7f04819-1f85-47eb-bd2c-8a1b269d4893"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""70aea1ce-3858-48dd-9354-3b338fcce845"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""75f9e4d7-bee1-4a74-9efb-9c14e18765e1"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9f0517cf-d6a0-4f98-ac7b-bb7846f4387a"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""95d025b7-3122-4acc-b641-4bfb47e9d521"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ccf817d-c250-4085-87ce-e52d163b69a2"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1641fb5d-173e-4d03-aa87-bd09ae575498"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Use Potion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""fbcf5df7-b341-4280-a0c7-ed3c97aad3bf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Wizard
        m_Wizard = asset.FindActionMap("Wizard", throwIfNotFound: true);
        m_Wizard_Move = m_Wizard.FindAction("Move", throwIfNotFound: true);
        m_Wizard_Shoot = m_Wizard.FindAction("Shoot", throwIfNotFound: true);
        m_Wizard_Melee = m_Wizard.FindAction("Melee", throwIfNotFound: true);
        m_Wizard_UsePotion = m_Wizard.FindAction("Use Potion", throwIfNotFound: true);
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
    private readonly InputAction m_Wizard_Shoot;
    private readonly InputAction m_Wizard_Melee;
    private readonly InputAction m_Wizard_UsePotion;
    public struct WizardActions
    {
        private @WizardInput m_Wrapper;
        public WizardActions(@WizardInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Wizard_Move;
        public InputAction @Shoot => m_Wrapper.m_Wizard_Shoot;
        public InputAction @Melee => m_Wrapper.m_Wizard_Melee;
        public InputAction @UsePotion => m_Wrapper.m_Wizard_UsePotion;
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
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Melee.started += instance.OnMelee;
            @Melee.performed += instance.OnMelee;
            @Melee.canceled += instance.OnMelee;
            @UsePotion.started += instance.OnUsePotion;
            @UsePotion.performed += instance.OnUsePotion;
            @UsePotion.canceled += instance.OnUsePotion;
        }

        private void UnregisterCallbacks(IWizardActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Melee.started -= instance.OnMelee;
            @Melee.performed -= instance.OnMelee;
            @Melee.canceled -= instance.OnMelee;
            @UsePotion.started -= instance.OnUsePotion;
            @UsePotion.performed -= instance.OnUsePotion;
            @UsePotion.canceled -= instance.OnUsePotion;
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
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IWizardActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnUsePotion(InputAction.CallbackContext context);
    }
}
