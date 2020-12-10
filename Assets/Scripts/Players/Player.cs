using System;
using Dungeoneer.Managers;
using Dungeoneer.Players.Characters;
using Dungeoneer.Steamworks;
using Steamworks;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Dungeoneer.Players
{
    public class Player : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<CSteamID, Player> { }

        private GameManager _gameManager;

        private Character _character;
        private bool _isOwner;

        [Inject]
        public void Constructor(bool isOwner, GameManager gameManager, SignalBus signalBus, PlayerActionControls controls)
        {
            _isOwner = isOwner;
            _gameManager = gameManager;
        }
    }

}

