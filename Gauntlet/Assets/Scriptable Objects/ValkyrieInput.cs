//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scriptable Objects/ValkyrieInput.inputactions
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

public partial class @ValkyrieInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ValkyrieInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ValkyrieInput"",
    ""maps"": [
        {
            ""name"": ""Valkyrie"",
            ""id"": ""c50280be-a27a-4b76-9edb-5b2125af6d4b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""70a77c76-381f-453f-9e7b-a03930930a5d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""d50b1a38-a369-4cc8-94d6-c10d9fc4f567"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""52e046c2-8586-4851-b0a0-527efeff8b9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Use Potion"",
                    ""type"": ""Button"",
                    ""id"": ""2de304f1-65ae-4c4b-8295-769e29c44a3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8825d0d8-481b-455d-8333-c2c55b496146"",
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
                    ""id"": ""90fa7c2d-f1ae-4787-ba83-bc46bd125611"",
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
                    ""id"": ""de782d44-a29f-43f4-ae6f-610be0f48c06"",
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
                    ""id"": ""b7e12054-a31a-43e1-9a72-304250b88170"",
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
                    ""id"": ""83e10808-5cb2-4688-a6e5-90fb6b2b87c8"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""539d50b2-efec-4537-9dc7-eb2b8e32ed54"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70bf067e-0a55-4264-b60b-c93e4f4f5d12"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d07cf21-aee8-4010-a462-d2f3b480e70c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""901131d7-2393-4954-ad60-2f1d3c93de66"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Potion"",
                    ""isComposite"": false,
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
        // Valkyrie
        m_Valkyrie = asset.FindActionMap("Valkyrie", throwIfNotFound: true);
        m_Valkyrie_Move = m_Valkyrie.FindAction("Move", throwIfNotFound: true);
        m_Valkyrie_Shoot = m_Valkyrie.FindAction("Shoot", throwIfNotFound: true);
        m_Valkyrie_Melee = m_Valkyrie.FindAction("Melee", throwIfNotFound: true);
        m_Valkyrie_UsePotion = m_Valkyrie.FindAction("Use Potion", throwIfNotFound: true);
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

    // Valkyrie
    private readonly InputActionMap m_Valkyrie;
    private List<IValkyrieActions> m_ValkyrieActionsCallbackInterfaces = new List<IValkyrieActions>();
    private readonly InputAction m_Valkyrie_Move;
    private readonly InputAction m_Valkyrie_Shoot;
    private readonly InputAction m_Valkyrie_Melee;
    private readonly InputAction m_Valkyrie_UsePotion;
    public struct ValkyrieActions
    {
        private @ValkyrieInput m_Wrapper;
        public ValkyrieActions(@ValkyrieInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Valkyrie_Move;
        public InputAction @Shoot => m_Wrapper.m_Valkyrie_Shoot;
        public InputAction @Melee => m_Wrapper.m_Valkyrie_Melee;
        public InputAction @UsePotion => m_Wrapper.m_Valkyrie_UsePotion;
        public InputActionMap Get() { return m_Wrapper.m_Valkyrie; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ValkyrieActions set) { return set.Get(); }
        public void AddCallbacks(IValkyrieActions instance)
        {
            if (instance == null || m_Wrapper.m_ValkyrieActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ValkyrieActionsCallbackInterfaces.Add(instance);
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

        private void UnregisterCallbacks(IValkyrieActions instance)
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

        public void RemoveCallbacks(IValkyrieActions instance)
        {
            if (m_Wrapper.m_ValkyrieActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IValkyrieActions instance)
        {
            foreach (var item in m_Wrapper.m_ValkyrieActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ValkyrieActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ValkyrieActions @Valkyrie => new ValkyrieActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IValkyrieActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnUsePotion(InputAction.CallbackContext context);
    }
}
