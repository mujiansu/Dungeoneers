using Steamworks;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Player : MonoBehaviour
{
    public InputAction ToggleMenuAction;

    private GameManager _gameManager;

    public CSteamID Owner { get; private set; }

    private Character _character;

    public class Factory : PlaceholderFactory<CSteamID, Player> { }

    [Inject]
    public void Constructor(GameManager gameManager, CSteamID owner)
    {
        Owner = owner;
        gameManager.SignalBus.Subscribe<GameManager.CloseMenuSignal>(OnCloseMenuSignal);
        gameManager.SignalBus.Subscribe<GameManager.OpenMenuSignal>(OnOpenMenuSignal);
        _gameManager = gameManager;
    }

    private void Start()
    {
        var character = GetComponentInChildren<Character>();
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
