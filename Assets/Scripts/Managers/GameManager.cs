using System;
using System.Collections.Generic;
using System.Linq;
using Dungeoneer.Players;
using Steamworks;
using UnityEngine;
using Zenject;
using static Dungeoneer.Managers.SceneChangingManager;

namespace Dungeoneer.Managers
{

    public class GameManager : IInitializable, IDisposable, ITickable
    {
        public GameObject PlayersContainer;

        private SignalBus _signalBus;
        private LobbyManager _lobbyManager;
        private PlayerFacade.Factory _playerFactory;
        private SceneChangingManager _sceneManager;

        private Dictionary<CSteamID, PlayerFacade> _players = new Dictionary<CSteamID, PlayerFacade>();


        [Inject]
        public void Constructor(SignalBus signalBus, LobbyManager lobbyManager, PlayerFacade.Factory playerFactory, SceneChangingManager sceneManger)
        {
            _signalBus = signalBus;
            _lobbyManager = lobbyManager;
            _playerFactory = playerFactory;
            _sceneManager = sceneManger;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<LobbyManager.MembersUpdateSignal>(OnMembersUpdateSignal);
            foreach (var member in _lobbyManager.Lobby.Members)
            {
                var player = _playerFactory.Create(member);
                player.SetParent(PlayersContainer);
                _players.Add(member, player);
            }
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<LobbyManager.MembersUpdateSignal>(OnMembersUpdateSignal);
        }

        public void Tick()
        {
        }

        private void OnMembersUpdateSignal()
        {
            foreach (var member in _lobbyManager.Lobby.Members)
            {
                if (!_players.ContainsKey(member))
                {
                    var playerInst = _playerFactory.Create(member);
                    playerInst.SetParent(PlayersContainer);
                    _players.Add(member, playerInst);
                }
            }
            _players.Where(x => !_lobbyManager.Lobby.Members.Contains(x.Key)).Select(x =>
            {
                GameObject.Destroy(x.Value.GameObject);
                _players.Remove(x.Key);
                return x.Key;
            });
        }
    }
}
