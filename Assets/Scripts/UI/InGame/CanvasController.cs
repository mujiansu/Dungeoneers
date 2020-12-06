using System.Collections.Generic;
using Dungeoneer.Managers;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Dugeoneer.Ui.InGame
{
    public class CanvasController : MonoBehaviour
    {
        public InputAction EscapeAction;
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

        private GameManager _gameManager;

        [Inject]
        public void Constructor(GameManager gameManager, SignalBus signalBus)
        {
            signalBus.Subscribe<GameManager.OpenMenuSignal>(OnOpenMenuSignal);
            signalBus.Subscribe<GameManager.CloseMenuSignal>(OnCloseMenuSignal);
            _gameManager = gameManager;
        }

        private void OnCloseMenuSignal()
        {
            foreach (var canvas in _canvases)
            {
                canvas.Value.transform.gameObject.SetActive(false);
            }
            _currentCanvas = CanvasType.Closed;
            EscapeAction.Disable();
        }

        private void OnOpenMenuSignal()
        {
            SwitchCanvas(CanvasType.StartMenu);
        }

        void Start()
        {
            _canvases.Add(CanvasType.StartMenu, StartMenuCanvas);
            _canvases.Add(CanvasType.InviteMenu, InviteMenuCanvas);
            _canvases.Add(CanvasType.ScoreScreen, ScoreScreenCanvas);
        }


        public void SwitchCanvas(CanvasType type)
        {
            if (type == CanvasType.Closed) throw new System.Exception("Cannot switch to closed canvas type.");
            if (type == _currentCanvas) return;
            EscapeAction.Enable();
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
                if (EscapeAction.triggered)
                {
                    if (_currentCanvas == CanvasType.StartMenu) _gameManager.CloseMenu();
                    else SwitchCanvas(CanvasType.StartMenu);
                }
            }
        }
    }
}

