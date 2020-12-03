using System;
using UnityEngine;
using Zenject;

public class GameManager : IInitializable, IDisposable, ITickable
{
    public class OpenMenuSignal { }

    public class CloseMenuSignal { }

    public GameObject PlayersContainer;

    public SignalBus SignalBus { get; private set; }
    private LobbyManager _lobbyManager;
    private Player.Factory _playerFactory;

    private bool IsMenuOpen = false;

    [Inject]
    public void Constructor(SignalBus signalBus, LobbyManager lobbyManager, Player.Factory playerFactory)
    {
        SignalBus = signalBus;
        _lobbyManager = lobbyManager;
        _playerFactory = playerFactory;
    }

    public void OpenMenu()
    {
        IsMenuOpen = true;
        SignalBus.Fire<OpenMenuSignal>();
    }

    public void CloseMenu()
    {
        IsMenuOpen = false;
        SignalBus.Fire<CloseMenuSignal>();
    }

    public void ToggleMenu()
    {
        if (IsMenuOpen) CloseMenu();
        else OpenMenu();
    }


    public void Initialize()
    {
        foreach (var member in _lobbyManager.Lobby.Members)
        {
            var player = _playerFactory.Create(member);
            player.transform.SetParent(PlayersContainer.transform);
        }
    }

    public void Dispose()
    {
    }

    public void Tick()
    {
    }
}
