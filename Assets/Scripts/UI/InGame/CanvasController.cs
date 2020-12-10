using System;
using System.Collections.Generic;
using Dungeoneer.Managers;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Dungeoneer.Ui.InGame
{
    public class CanvasController : MonoBehaviour
    {
        public Canvas InviteMenuCanvas;
        public Canvas StartMenuCanvas;
        public Canvas ScoreScreenCanvas;
        private CanvasType _currentCanvas;
        public enum CanvasType
        {
            Closed,
            StartMenu,
            InviteMenu,
            ScoreScreen
        }

        private Dictionary<CanvasType, Canvas> _canvases = new Dictionary<CanvasType, Canvas>();

        private SignalBus _signalBus;
        private PlayerActionControls.GameMenuActions _menuControls;
        public class MenuStateChangeSignal { public bool IsOpen { get; internal set; } }
        public class DisableMenuSignal { public bool Value { get; set; } }
        public class EnableMenuSignal { public bool Value { get; set; } }

        [Inject]
        public void Constructor(SignalBus signalBus, PlayerActionControls controls)
        {
            _signalBus = signalBus;
            _menuControls = controls.GameMenu;
        }

        void Start()
        {
            _signalBus.Subscribe<DisableMenuSignal>(OnDisableMenuSignal);
            _signalBus.Subscribe<EnableMenuSignal>(OnEnableMenuSignal);
            _menuControls.Enable();
            _canvases.Add(CanvasType.StartMenu, StartMenuCanvas);
            _canvases.Add(CanvasType.InviteMenu, InviteMenuCanvas);
            _canvases.Add(CanvasType.ScoreScreen, ScoreScreenCanvas);
        }

        private void CloseMenu()
        {
            foreach (var canvas in _canvases)
            {
                canvas.Value.transform.gameObject.SetActive(false);
            }
            _currentCanvas = CanvasType.Closed;
            _signalBus.Fire<MenuStateChangeSignal>(new MenuStateChangeSignal { IsOpen = false });
        }

        private void OpenMenu()
        {
            SwitchCanvas(CanvasType.StartMenu);
            _signalBus.Fire<MenuStateChangeSignal>(new MenuStateChangeSignal { IsOpen = true });
        }



        private void OnEnableMenuSignal()
        {
            _menuControls.Enable();
        }

        private void OnDisableMenuSignal()
        {
            if (_currentCanvas != CanvasType.Closed) CloseMenu();
            _menuControls.Disable();
        }

        public void SwitchCanvas(CanvasType type)
        {
            if (type == CanvasType.Closed) throw new System.Exception("Cannot switch to closed canvas type.");
            if (type == _currentCanvas) return;
            _currentCanvas = type;
            foreach (var canvas in _canvases)
            {
                if (canvas.Key == type) canvas.Value.transform.gameObject.SetActive(true);
                else canvas.Value.transform.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (_currentCanvas != CanvasType.Closed)
            {
                if (_menuControls.ToggleOrBack.triggered)
                {
                    if (_currentCanvas == CanvasType.StartMenu) CloseMenu();
                    else SwitchCanvas(CanvasType.StartMenu);
                }
            }
            else
            {
                if (_menuControls.ToggleOrBack.triggered)
                {
                    OpenMenu();
                }
            }
        }
    }
}

