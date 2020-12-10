// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActionControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActionControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d9f08509-d6b4-4f12-bbc2-d78de6aed68c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""d3c04f9b-62ac-4f46-a828-872982b1b718"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""e2511a8a-9cde-4d7a-b094-e094cdd85bfd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stop"",
                    ""type"": ""Button"",
                    ""id"": ""46bdd9cb-2259-4622-b4e3-17a67f41694c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CastSpell"",
                    ""type"": ""Button"",
                    ""id"": ""9e48678e-0c35-4be5-91a3-2a562fe6afc6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b2d687f-6c01-47ed-9595-a2c29bb3fd3f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee4ca8fc-0853-420d-be1a-27ee07b8ebf8"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cec51d58-e5c7-45e3-955c-7375e477d5c5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""821e6037-0c8b-4e08-a819-d9f1546c3d31"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameMenu"",
            ""id"": ""7ccd2aca-4ed1-4d48-b6e2-1696c52fa500"",
            ""actions"": [
                {
                    ""name"": ""ToggleOrBack"",
                    ""type"": ""Button"",
                    ""id"": ""2bc78b56-4979-4279-ab63-5ea07611de5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""38bc887c-8c41-46d8-be77-3ac87e2e286a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""29ce3e16-7cb0-4b17-8846-5daa72ffb482"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleOrBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d1aade2-1769-40a3-be66-4d2092a75ca3"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_MousePosition = m_Player.FindAction("MousePosition", throwIfNotFound: true);
        m_Player_Stop = m_Player.FindAction("Stop", throwIfNotFound: true);
        m_Player_CastSpell = m_Player.FindAction("CastSpell", throwIfNotFound: true);
        // GameMenu
        m_GameMenu = asset.FindActionMap("GameMenu", throwIfNotFound: true);
        m_GameMenu_ToggleOrBack = m_GameMenu.FindAction("ToggleOrBack", throwIfNotFound: true);
        m_GameMenu_OpenMenu = m_GameMenu.FindAction("OpenMenu", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_MousePosition;
    private readonly InputAction m_Player_Stop;
    private readonly InputAction m_Player_CastSpell;
    public struct PlayerActions
    {
        private @PlayerActionControls m_Wrapper;
        public PlayerActions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @MousePosition => m_Wrapper.m_Player_MousePosition;
        public InputAction @Stop => m_Wrapper.m_Player_Stop;
        public InputAction @CastSpell => m_Wrapper.m_Player_CastSpell;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @MousePosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @Stop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStop;
                @Stop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStop;
                @Stop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStop;
                @CastSpell.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell;
                @CastSpell.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell;
                @CastSpell.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Stop.started += instance.OnStop;
                @Stop.performed += instance.OnStop;
                @Stop.canceled += instance.OnStop;
                @CastSpell.started += instance.OnCastSpell;
                @CastSpell.performed += instance.OnCastSpell;
                @CastSpell.canceled += instance.OnCastSpell;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // GameMenu
    private readonly InputActionMap m_GameMenu;
    private IGameMenuActions m_GameMenuActionsCallbackInterface;
    private readonly InputAction m_GameMenu_ToggleOrBack;
    private readonly InputAction m_GameMenu_OpenMenu;
    public struct GameMenuActions
    {
        private @PlayerActionControls m_Wrapper;
        public GameMenuActions(@PlayerActionControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleOrBack => m_Wrapper.m_GameMenu_ToggleOrBack;
        public InputAction @OpenMenu => m_Wrapper.m_GameMenu_OpenMenu;
        public InputActionMap Get() { return m_Wrapper.m_GameMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameMenuActions set) { return set.Get(); }
        public void SetCallbacks(IGameMenuActions instance)
        {
            if (m_Wrapper.m_GameMenuActionsCallbackInterface != null)
            {
                @ToggleOrBack.started -= m_Wrapper.m_GameMenuActionsCallbackInterface.OnToggleOrBack;
                @ToggleOrBack.performed -= m_Wrapper.m_GameMenuActionsCallbackInterface.OnToggleOrBack;
                @ToggleOrBack.canceled -= m_Wrapper.m_GameMenuActionsCallbackInterface.OnToggleOrBack;
                @OpenMenu.started -= m_Wrapper.m_GameMenuActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.performed -= m_Wrapper.m_GameMenuActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.canceled -= m_Wrapper.m_GameMenuActionsCallbackInterface.OnOpenMenu;
            }
            m_Wrapper.m_GameMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleOrBack.started += instance.OnToggleOrBack;
                @ToggleOrBack.performed += instance.OnToggleOrBack;
                @ToggleOrBack.canceled += instance.OnToggleOrBack;
                @OpenMenu.started += instance.OnOpenMenu;
                @OpenMenu.performed += instance.OnOpenMenu;
                @OpenMenu.canceled += instance.OnOpenMenu;
            }
        }
    }
    public GameMenuActions @GameMenu => new GameMenuActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnStop(InputAction.CallbackContext context);
        void OnCastSpell(InputAction.CallbackContext context);
    }
    public interface IGameMenuActions
    {
        void OnToggleOrBack(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
    }
}
