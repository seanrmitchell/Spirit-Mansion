//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Controller.inputactions
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

public partial class @Controller : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""bf2922b7-8ac5-493e-8439-e56cd049e815"",
            ""actions"": [
                {
                    ""name"": ""WASD"",
                    ""type"": ""Button"",
                    ""id"": ""6eadf262-5f6d-4569-bbb1-f308b8477648"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Vertical"",
                    ""id"": ""c132a700-dab3-44e7-999a-828fc17caf1d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f1d3918f-8d36-45df-9bba-856b83897940"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6a684439-d4d6-4308-a8d4-acbb3f2e9d38"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Horizontal"",
                    ""id"": ""f2bfea7d-b852-44c4-9107-d63b399ca059"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""56c97b9c-1599-4f35-b9b9-3eabd33aeddf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0425afa3-d9a5-4255-b686-535c1ee83f98"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Attack"",
            ""id"": ""a1c7b17a-688e-4d60-8a31-441ba66f6d30"",
            ""actions"": [
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""e8847530-1660-46b4-a8b9-47fa8b7e46d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""0ceb6f21-632f-4fb7-9673-80c2506b52ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cb5190dc-9517-4df7-8705-1ed3105c4387"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61b4625f-3ee6-4a16-a514-648255c721e1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause"",
            ""id"": ""13ed1b99-691f-4dd7-b682-f8cf5539fdf3"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""2d7329e4-d731-485d-9716-3d973b7c860b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""83986834-eb0e-46f7-9b9a-18ede2bb5645"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Cutscene Skip"",
            ""id"": ""b29db63a-18ea-4078-9236-99fbab8087b5"",
            ""actions"": [
                {
                    ""name"": ""Skip"",
                    ""type"": ""Button"",
                    ""id"": ""e5be7e1c-d4ba-4467-9bf3-941e4b281b4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6543e314-c57d-4238-a11a-523992508c5f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_WASD = m_Movement.FindAction("WASD", throwIfNotFound: true);
        // Attack
        m_Attack = asset.FindActionMap("Attack", throwIfNotFound: true);
        m_Attack_Primary = m_Attack.FindAction("Primary", throwIfNotFound: true);
        m_Attack_Secondary = m_Attack.FindAction("Secondary", throwIfNotFound: true);
        // Pause
        m_Pause = asset.FindActionMap("Pause", throwIfNotFound: true);
        m_Pause_Pause = m_Pause.FindAction("Pause", throwIfNotFound: true);
        // Cutscene Skip
        m_CutsceneSkip = asset.FindActionMap("Cutscene Skip", throwIfNotFound: true);
        m_CutsceneSkip_Skip = m_CutsceneSkip.FindAction("Skip", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_WASD;
    public struct MovementActions
    {
        private @Controller m_Wrapper;
        public MovementActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASD => m_Wrapper.m_Movement_WASD;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @WASD.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnWASD;
                @WASD.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnWASD;
                @WASD.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnWASD;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WASD.started += instance.OnWASD;
                @WASD.performed += instance.OnWASD;
                @WASD.canceled += instance.OnWASD;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Attack
    private readonly InputActionMap m_Attack;
    private IAttackActions m_AttackActionsCallbackInterface;
    private readonly InputAction m_Attack_Primary;
    private readonly InputAction m_Attack_Secondary;
    public struct AttackActions
    {
        private @Controller m_Wrapper;
        public AttackActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Primary => m_Wrapper.m_Attack_Primary;
        public InputAction @Secondary => m_Wrapper.m_Attack_Secondary;
        public InputActionMap Get() { return m_Wrapper.m_Attack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackActions set) { return set.Get(); }
        public void SetCallbacks(IAttackActions instance)
        {
            if (m_Wrapper.m_AttackActionsCallbackInterface != null)
            {
                @Primary.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnPrimary;
                @Primary.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnPrimary;
                @Primary.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnPrimary;
                @Secondary.started -= m_Wrapper.m_AttackActionsCallbackInterface.OnSecondary;
                @Secondary.performed -= m_Wrapper.m_AttackActionsCallbackInterface.OnSecondary;
                @Secondary.canceled -= m_Wrapper.m_AttackActionsCallbackInterface.OnSecondary;
            }
            m_Wrapper.m_AttackActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Primary.started += instance.OnPrimary;
                @Primary.performed += instance.OnPrimary;
                @Primary.canceled += instance.OnPrimary;
                @Secondary.started += instance.OnSecondary;
                @Secondary.performed += instance.OnSecondary;
                @Secondary.canceled += instance.OnSecondary;
            }
        }
    }
    public AttackActions @Attack => new AttackActions(this);

    // Pause
    private readonly InputActionMap m_Pause;
    private IPauseActions m_PauseActionsCallbackInterface;
    private readonly InputAction m_Pause_Pause;
    public struct PauseActions
    {
        private @Controller m_Wrapper;
        public PauseActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Pause_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Pause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActions set) { return set.Get(); }
        public void SetCallbacks(IPauseActions instance)
        {
            if (m_Wrapper.m_PauseActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PauseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PauseActions @Pause => new PauseActions(this);

    // Cutscene Skip
    private readonly InputActionMap m_CutsceneSkip;
    private ICutsceneSkipActions m_CutsceneSkipActionsCallbackInterface;
    private readonly InputAction m_CutsceneSkip_Skip;
    public struct CutsceneSkipActions
    {
        private @Controller m_Wrapper;
        public CutsceneSkipActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Skip => m_Wrapper.m_CutsceneSkip_Skip;
        public InputActionMap Get() { return m_Wrapper.m_CutsceneSkip; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CutsceneSkipActions set) { return set.Get(); }
        public void SetCallbacks(ICutsceneSkipActions instance)
        {
            if (m_Wrapper.m_CutsceneSkipActionsCallbackInterface != null)
            {
                @Skip.started -= m_Wrapper.m_CutsceneSkipActionsCallbackInterface.OnSkip;
                @Skip.performed -= m_Wrapper.m_CutsceneSkipActionsCallbackInterface.OnSkip;
                @Skip.canceled -= m_Wrapper.m_CutsceneSkipActionsCallbackInterface.OnSkip;
            }
            m_Wrapper.m_CutsceneSkipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Skip.started += instance.OnSkip;
                @Skip.performed += instance.OnSkip;
                @Skip.canceled += instance.OnSkip;
            }
        }
    }
    public CutsceneSkipActions @CutsceneSkip => new CutsceneSkipActions(this);
    public interface IMovementActions
    {
        void OnWASD(InputAction.CallbackContext context);
    }
    public interface IAttackActions
    {
        void OnPrimary(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
    }
    public interface IPauseActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
    public interface ICutsceneSkipActions
    {
        void OnSkip(InputAction.CallbackContext context);
    }
}
