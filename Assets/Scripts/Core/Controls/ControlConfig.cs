// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Core/Controls/ControlConfig.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControlConfig : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlConfig()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlConfig"",
    ""maps"": [
        {
            ""name"": ""Controls.Player"",
            ""id"": ""58ec2899-3e99-4cae-b5d1-c9c3a0569fe7"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""18a8f6c8-4d1b-478b-b99a-5da1f15fb4b3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MovePlayer"",
                    ""type"": ""Button"",
                    ""id"": ""ed39f642-448d-4e38-8443-598e8d6f4132"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenGameMenu"",
                    ""type"": ""Button"",
                    ""id"": ""d56bc429-7762-4ed3-9b76-01cfd44997df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""type"": ""Value"",
                    ""id"": ""20911213-cecc-42bc-bf78-3df07b80ed20"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ea3c6525-d19a-4db0-8f6d-05df0f3595c6"",
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
                    ""id"": ""527d83d3-d3f4-4a6a-bd27-a28fae01f7bd"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePlayer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8ac62ee-13d9-4173-a207-96873e7c47b4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenGameMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5c4bb0dd-d292-482d-b103-c18e0cd51d0c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""725ab276-9159-41bf-bf10-c99ef1671039"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3c7b880b-7512-4a70-a4da-fcc3b8a2c195"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""71bebd93-dea6-42d6-a5ef-d22c5771098e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0e562154-333a-4814-81af-6e9cd8de57d6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Controls.GameMenu"",
            ""id"": ""5d685a30-a93e-401d-8ea5-fba09e449053"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""6a5be69e-3977-4fbd-a4a2-35eaade7de8b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MakeSelection"",
                    ""type"": ""Button"",
                    ""id"": ""6c270bd8-b7ca-4d47-8664-b7c2aabff76a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""54d84f95-1c3c-4b85-b827-fcdee401ec1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""type"": ""Value"",
                    ""id"": ""45018eb2-f447-4b0e-9737-c7b678afb4a2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ac2c8496-5407-49fb-b719-9bd93c0e5fe6"",
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
                    ""id"": ""16d0bc40-4dc9-48d0-a84b-45390a6ae44f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MakeSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bcf9d52-6519-4bc3-9a4f-88e6d8f4cc99"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""453f4744-05fa-4a43-a0a7-b24a44a9fc7c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9ae0f05b-1c98-41e8-a5de-ffbc39e7b9c7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""459a861d-dca0-4048-80a3-7875e5f8ea1f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""49e2ac0a-7ac9-4816-87b4-5c37611cbec7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""18443210-c708-4ea9-907b-4336b296dd2c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Controls.Player
        m_ControlsPlayer = asset.FindActionMap("Controls.Player", throwIfNotFound: true);
        m_ControlsPlayer_MousePosition = m_ControlsPlayer.FindAction("MousePosition", throwIfNotFound: true);
        m_ControlsPlayer_MovePlayer = m_ControlsPlayer.FindAction("MovePlayer", throwIfNotFound: true);
        m_ControlsPlayer_OpenGameMenu = m_ControlsPlayer.FindAction("OpenGameMenu", throwIfNotFound: true);
        m_ControlsPlayer_ArrowKeys = m_ControlsPlayer.FindAction("ArrowKeys", throwIfNotFound: true);
        // Controls.GameMenu
        m_ControlsGameMenu = asset.FindActionMap("Controls.GameMenu", throwIfNotFound: true);
        m_ControlsGameMenu_MousePosition = m_ControlsGameMenu.FindAction("MousePosition", throwIfNotFound: true);
        m_ControlsGameMenu_MakeSelection = m_ControlsGameMenu.FindAction("MakeSelection", throwIfNotFound: true);
        m_ControlsGameMenu_Back = m_ControlsGameMenu.FindAction("Back", throwIfNotFound: true);
        m_ControlsGameMenu_ArrowKeys = m_ControlsGameMenu.FindAction("ArrowKeys", throwIfNotFound: true);
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

    // Controls.Player
    private readonly InputActionMap m_ControlsPlayer;
    private IControlsPlayerActions m_ControlsPlayerActionsCallbackInterface;
    private readonly InputAction m_ControlsPlayer_MousePosition;
    private readonly InputAction m_ControlsPlayer_MovePlayer;
    private readonly InputAction m_ControlsPlayer_OpenGameMenu;
    private readonly InputAction m_ControlsPlayer_ArrowKeys;
    public struct ControlsPlayerActions
    {
        private @ControlConfig m_Wrapper;
        public ControlsPlayerActions(@ControlConfig wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_ControlsPlayer_MousePosition;
        public InputAction @MovePlayer => m_Wrapper.m_ControlsPlayer_MovePlayer;
        public InputAction @OpenGameMenu => m_Wrapper.m_ControlsPlayer_OpenGameMenu;
        public InputAction @ArrowKeys => m_Wrapper.m_ControlsPlayer_ArrowKeys;
        public InputActionMap Get() { return m_Wrapper.m_ControlsPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsPlayerActions set) { return set.Get(); }
        public void SetCallbacks(IControlsPlayerActions instance)
        {
            if (m_Wrapper.m_ControlsPlayerActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnMousePosition;
                @MovePlayer.started -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnMovePlayer;
                @MovePlayer.performed -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnMovePlayer;
                @MovePlayer.canceled -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnMovePlayer;
                @OpenGameMenu.started -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnOpenGameMenu;
                @OpenGameMenu.performed -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnOpenGameMenu;
                @OpenGameMenu.canceled -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnOpenGameMenu;
                @ArrowKeys.started -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnArrowKeys;
                @ArrowKeys.performed -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnArrowKeys;
                @ArrowKeys.canceled -= m_Wrapper.m_ControlsPlayerActionsCallbackInterface.OnArrowKeys;
            }
            m_Wrapper.m_ControlsPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MovePlayer.started += instance.OnMovePlayer;
                @MovePlayer.performed += instance.OnMovePlayer;
                @MovePlayer.canceled += instance.OnMovePlayer;
                @OpenGameMenu.started += instance.OnOpenGameMenu;
                @OpenGameMenu.performed += instance.OnOpenGameMenu;
                @OpenGameMenu.canceled += instance.OnOpenGameMenu;
                @ArrowKeys.started += instance.OnArrowKeys;
                @ArrowKeys.performed += instance.OnArrowKeys;
                @ArrowKeys.canceled += instance.OnArrowKeys;
            }
        }
    }
    public ControlsPlayerActions @ControlsPlayer => new ControlsPlayerActions(this);

    // Controls.GameMenu
    private readonly InputActionMap m_ControlsGameMenu;
    private IControlsGameMenuActions m_ControlsGameMenuActionsCallbackInterface;
    private readonly InputAction m_ControlsGameMenu_MousePosition;
    private readonly InputAction m_ControlsGameMenu_MakeSelection;
    private readonly InputAction m_ControlsGameMenu_Back;
    private readonly InputAction m_ControlsGameMenu_ArrowKeys;
    public struct ControlsGameMenuActions
    {
        private @ControlConfig m_Wrapper;
        public ControlsGameMenuActions(@ControlConfig wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_ControlsGameMenu_MousePosition;
        public InputAction @MakeSelection => m_Wrapper.m_ControlsGameMenu_MakeSelection;
        public InputAction @Back => m_Wrapper.m_ControlsGameMenu_Back;
        public InputAction @ArrowKeys => m_Wrapper.m_ControlsGameMenu_ArrowKeys;
        public InputActionMap Get() { return m_Wrapper.m_ControlsGameMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsGameMenuActions set) { return set.Get(); }
        public void SetCallbacks(IControlsGameMenuActions instance)
        {
            if (m_Wrapper.m_ControlsGameMenuActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnMousePosition;
                @MakeSelection.started -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnMakeSelection;
                @MakeSelection.performed -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnMakeSelection;
                @MakeSelection.canceled -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnMakeSelection;
                @Back.started -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnBack;
                @ArrowKeys.started -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnArrowKeys;
                @ArrowKeys.performed -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnArrowKeys;
                @ArrowKeys.canceled -= m_Wrapper.m_ControlsGameMenuActionsCallbackInterface.OnArrowKeys;
            }
            m_Wrapper.m_ControlsGameMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MakeSelection.started += instance.OnMakeSelection;
                @MakeSelection.performed += instance.OnMakeSelection;
                @MakeSelection.canceled += instance.OnMakeSelection;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @ArrowKeys.started += instance.OnArrowKeys;
                @ArrowKeys.performed += instance.OnArrowKeys;
                @ArrowKeys.canceled += instance.OnArrowKeys;
            }
        }
    }
    public ControlsGameMenuActions @ControlsGameMenu => new ControlsGameMenuActions(this);
    public interface IControlsPlayerActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMovePlayer(InputAction.CallbackContext context);
        void OnOpenGameMenu(InputAction.CallbackContext context);
        void OnArrowKeys(InputAction.CallbackContext context);
    }
    public interface IControlsGameMenuActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMakeSelection(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnArrowKeys(InputAction.CallbackContext context);
    }
}
