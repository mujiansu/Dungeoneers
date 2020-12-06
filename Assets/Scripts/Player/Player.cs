using Steamworks;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Player : MonoBehaviour
{
    public class Factory : PlaceholderFactory<CSteamID, Player> { }
    public InputAction ToggleMenuAction;

    private GameManager _gameManager;

    public CSteamID Owner { get; private set; }

    private Character _character;

    [Inject]
    public void Constructor(CSteamID owner, GameManager gameManager, SignalBus signalBus)
    {
        Owner = owner;
        signalBus.Subscribe<GameManager.CloseMenuSignal>(OnCloseMenuSignal);
        signalBus.Subscribe<GameManager.OpenMenuSignal>(OnOpenMenuSignal);
        _gameManager = gameManager;
    }

    private void Start()
    {
        if (Owner == SteamHelpers.Me)
        {
            ToggleMenuAction.Enable();
        }
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
