using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Player : MonoBehaviour
{
    public InputAction ToggleMenuAction;

    private GameManager _gameManager;

    [Inject]
    public void Constructor(GameManager gameManager)
    {
        gameManager.SignalBus.Subscribe<GameManager.CloseMenuSignal>(OnCloseMenuSignal);
        gameManager.SignalBus.Subscribe<GameManager.OpenMenuSignal>(OnOpenMenuSignal);
        _gameManager = gameManager;
    }

    private void Awake()
    {
        ToggleMenuAction.Enable();
    }

    private void OnDisable()
    {
        ToggleMenuAction.Disable();
    }

    private void OnOpenMenuSignal()
    {
        ToggleMenuAction.Disable();
    }

    private void OnCloseMenuSignal()
    {
        ToggleMenuAction.Enable();
    }

    private void Update()
    {
        if (ToggleMenuAction.triggered)
        {
            _gameManager.OpenMenu();
        }
    }
}
