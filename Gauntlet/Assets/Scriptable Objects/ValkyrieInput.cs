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
            ""id"": ""deb3e2d4-2d0b-4a20-8c29-1020c468dd48"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""dd2e3a9e-80e3-462c-ac96-723224a546ce"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LookUp"",
                    ""type"": ""Button"",
                    ""id"": ""c34b52fe-a5f9-4e08-a151-49eb2b94291e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookDown"",
                    ""type"": ""Button"",
                    ""id"": ""2c21f9cf-93d9-4d70-ac20-a1e205985981"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookLeft"",
                    ""type"": ""Button"",
                    ""id"": ""2a3ad3bb-e158-45ee-a106-0ea47fe18cd1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookRight"",
                    ""type"": ""Button"",
                    ""id"": ""af4fab54-1d5f-4da5-bfd7-820c1b25f682"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""ee63dde7-eb93-420c-a8f9-1e649c049af1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""f8d13fd1-67fe-4545-bd2e-2fcb10a1f63a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""10f52379-85f3-4557-8b36-1b39fa4a4a33"",
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
                    ""id"": ""1c9b9fdf-b1c5-4f14-be10-da130850afdf"",
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
                    ""id"": ""fc8d835d-98f5-43b3-947b-66c9efc0d731"",
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
                    ""id"": ""82edc838-dbb3-4be6-b84b-3863b812040c"",
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
                    ""id"": ""709f6a66-ee08-4c40-8bbe-b6e655eb332f"",
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
                    ""id"": ""2558a30f-e12b-43ad-9352-7520c0875047"",
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
                    ""id"": ""0399d8df-2887-4e76-ac13-df6d6babb620"",
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
                    ""id"": ""0b981f5e-7e6d-4acc-be66-7e4f2522f814"",
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
                    ""id"": ""102e5b2b-a23c-40ad-bc0c-e375435ea7b2"",
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
                    ""id"": ""443379b8-85d5-4149-a030-da2809b050c8"",
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
                    ""id"": ""ba2bde79-efa2-4c52-bd98-e65645751538"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Valkyrie
        m_Valkyrie = asset.FindActionMap("Valkyrie", throwIfNotFound: true);
        m_Valkyrie_Move = m_Valkyrie.FindAction("Move", throwIfNotFound: true);
        m_Valkyrie_LookUp = m_Valkyrie.FindAction("LookUp", throwIfNotFound: true);
        m_Valkyrie_LookDown = m_Valkyrie.FindAction("LookDown", throwIfNotFound: true);
        m_Valkyrie_LookLeft = m_Valkyrie.FindAction("LookLeft", throwIfNotFound: true);
        m_Valkyrie_LookRight = m_Valkyrie.FindAction("LookRight", throwIfNotFound: true);
        m_Valkyrie_Shoot = m_Valkyrie.FindAction("Shoot", throwIfNotFound: true);
        m_Valkyrie_Melee = m_Valkyrie.FindAction("Melee", throwIfNotFound: true);
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
    private readonly InputAction m_Valkyrie_LookUp;
    private readonly InputAction m_Valkyrie_LookDown;
    private readonly InputAction m_Valkyrie_LookLeft;
    private readonly InputAction m_Valkyrie_LookRight;
    private readonly InputAction m_Valkyrie_Shoot;
    private readonly InputAction m_Valkyrie_Melee;
    public struct ValkyrieActions
    {
        private @ValkyrieInput m_Wrapper;
        public ValkyrieActions(@ValkyrieInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Valkyrie_Move;
        public InputAction @LookUp => m_Wrapper.m_Valkyrie_LookUp;
        public InputAction @LookDown => m_Wrapper.m_Valkyrie_LookDown;
        public InputAction @LookLeft => m_Wrapper.m_Valkyrie_LookLeft;
        public InputAction @LookRight => m_Wrapper.m_Valkyrie_LookRight;
        public InputAction @Shoot => m_Wrapper.m_Valkyrie_Shoot;
        public InputAction @Melee => m_Wrapper.m_Valkyrie_Melee;
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
            @Melee.started += instance.OnMelee;
            @Melee.performed += instance.OnMelee;
            @Melee.canceled += instance.OnMelee;
        }

        private void UnregisterCallbacks(IValkyrieActions instance)
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
            @Melee.started -= instance.OnMelee;
            @Melee.performed -= instance.OnMelee;
            @Melee.canceled -= instance.OnMelee;
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
    public interface IValkyrieActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLookUp(InputAction.CallbackContext context);
        void OnLookDown(InputAction.CallbackContext context);
        void OnLookLeft(InputAction.CallbackContext context);
        void OnLookRight(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
    }
}
