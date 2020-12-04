using System;
using System.Collections.Generic;
using System.Linq;
using Steamworks;
using UnityEngine;
using Zenject;

public class GameManager : IInitializable, IDisposable, ITickable
{
    public class OpenMenuSignal { }

    public class CloseMenuSignal { }

    public GameObject PlayersContainer;

    private SignalBus _signalBus;
    private LobbyManager _lobbyManager;
    private Player.Factory _playerFactory;

    private Dictionary<CSteamID, Player> _players;

    private bool IsMenuOpen = false;

    [Inject]
    public void Constructor(SignalBus signalBus, LobbyManager lobbyManager, Player.Factory playerFactory)
    {
        _signalBus = signalBus;
        _lobbyManager = lobbyManager;
        _playerFactory = playerFactory;
    }

    private void OnMembersUpdateSignal()
    {
        foreach (var member in _lobbyManager.Lobby.Members)
        {
            if (!_players.ContainsKey(member))
            {
                var playerInst = _playerFactory.Create(member);
                playerInst.transform.SetParent(PlayersContainer.transform);
            }
        }
        _players.Where(x => !_lobbyManager.Lobby.Members.Contains(x.Key)).Select(x =>
        {
            GameObject.Destroy(x.Value.gameObject);
            _players.Remove(x.Key);
            return x.Key;
        });
    }

    public void OpenMenu()
    {
        IsMenuOpen = true;
        _signalBus.Fire<OpenMenuSignal>();
    }

    public void CloseMenu()
    {
        IsMenuOpen = false;
        _signalBus.Fire<CloseMenuSignal>();
    }

    public void ToggleMenu()
    {
        if (IsMenuOpen) CloseMenu();
        else OpenMenu();
    }


    public void Initialize()
    {
        _signalBus.Subscribe<LobbyManager.MembersUpdateSignal>(OnMembersUpdateSignal);
        foreach (var member in _lobbyManager.Lobby.Members)
        {
            var player = _playerFactory.Create(member);
            player.transform.SetParent(PlayersContainer.transform);
        }
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<LobbyManager.MembersUpdateSignal>(OnMembersUpdateSignal);
    }

    public void Tick()
    {
    }
}
