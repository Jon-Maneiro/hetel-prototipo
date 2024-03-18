//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Nave/SpaceShip/InputActions.inputactions
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

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""ShipMovement"",
            ""id"": ""1b862e41-8479-4fc9-bf25-8c45df8d695e"",
            ""actions"": [
                {
                    ""name"": ""ForwardMovement"",
                    ""type"": ""Button"",
                    ""id"": ""cc8cda3b-dfd4-460a-a3ac-6105524ae0a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HorizontalMovement"",
                    ""type"": ""Button"",
                    ""id"": ""97c28d44-ec39-4e76-9a0e-c051111450f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateMovement"",
                    ""type"": ""Value"",
                    ""id"": ""de6d2e3d-1309-4f42-a447-d1bfeec5113e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""14f6e857-e8be-48c2-a6d1-c3df8a2a0694"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ForwardMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7a4a0042-00dc-456c-9f5c-5aedac5060c0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ForwardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""85fadff1-e976-4497-a3c9-b09d3d6ba56e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ForwardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""81db6a12-957c-4543-a588-19b2eb822309"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""21c56a45-5310-4f4a-a007-4e4ac91953fd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""710ac7dc-c259-42f5-a61b-2fc3d9511afa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ff14f227-aaa3-4d72-9e54-068d48078f03"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b2f9919f-83f7-47cf-9d27-30bbc492d010"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""69af1721-8a96-4d03-9fba-8ee9902ae493"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ShipMovement
        m_ShipMovement = asset.FindActionMap("ShipMovement", throwIfNotFound: true);
        m_ShipMovement_ForwardMovement = m_ShipMovement.FindAction("ForwardMovement", throwIfNotFound: true);
        m_ShipMovement_HorizontalMovement = m_ShipMovement.FindAction("HorizontalMovement", throwIfNotFound: true);
        m_ShipMovement_RotateMovement = m_ShipMovement.FindAction("RotateMovement", throwIfNotFound: true);
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

    // ShipMovement
    private readonly InputActionMap m_ShipMovement;
    private List<IShipMovementActions> m_ShipMovementActionsCallbackInterfaces = new List<IShipMovementActions>();
    private readonly InputAction m_ShipMovement_ForwardMovement;
    private readonly InputAction m_ShipMovement_HorizontalMovement;
    private readonly InputAction m_ShipMovement_RotateMovement;
    public struct ShipMovementActions
    {
        private @InputActions m_Wrapper;
        public ShipMovementActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ForwardMovement => m_Wrapper.m_ShipMovement_ForwardMovement;
        public InputAction @HorizontalMovement => m_Wrapper.m_ShipMovement_HorizontalMovement;
        public InputAction @RotateMovement => m_Wrapper.m_ShipMovement_RotateMovement;
        public InputActionMap Get() { return m_Wrapper.m_ShipMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipMovementActions set) { return set.Get(); }
        public void AddCallbacks(IShipMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_ShipMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ShipMovementActionsCallbackInterfaces.Add(instance);
            @ForwardMovement.started += instance.OnForwardMovement;
            @ForwardMovement.performed += instance.OnForwardMovement;
            @ForwardMovement.canceled += instance.OnForwardMovement;
            @HorizontalMovement.started += instance.OnHorizontalMovement;
            @HorizontalMovement.performed += instance.OnHorizontalMovement;
            @HorizontalMovement.canceled += instance.OnHorizontalMovement;
            @RotateMovement.started += instance.OnRotateMovement;
            @RotateMovement.performed += instance.OnRotateMovement;
            @RotateMovement.canceled += instance.OnRotateMovement;
        }

        private void UnregisterCallbacks(IShipMovementActions instance)
        {
            @ForwardMovement.started -= instance.OnForwardMovement;
            @ForwardMovement.performed -= instance.OnForwardMovement;
            @ForwardMovement.canceled -= instance.OnForwardMovement;
            @HorizontalMovement.started -= instance.OnHorizontalMovement;
            @HorizontalMovement.performed -= instance.OnHorizontalMovement;
            @HorizontalMovement.canceled -= instance.OnHorizontalMovement;
            @RotateMovement.started -= instance.OnRotateMovement;
            @RotateMovement.performed -= instance.OnRotateMovement;
            @RotateMovement.canceled -= instance.OnRotateMovement;
        }

        public void RemoveCallbacks(IShipMovementActions instance)
        {
            if (m_Wrapper.m_ShipMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IShipMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_ShipMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ShipMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ShipMovementActions @ShipMovement => new ShipMovementActions(this);
    public interface IShipMovementActions
    {
        void OnForwardMovement(InputAction.CallbackContext context);
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnRotateMovement(InputAction.CallbackContext context);
    }
}
