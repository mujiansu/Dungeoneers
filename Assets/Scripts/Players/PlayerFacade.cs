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
    public class Player
    {
        public class Factory : PlaceholderFactory<CSteamID, Player> { }
        private Transform _transform;

        public GameObject GameObject => _transform.gameObject;

        [Inject]
        public void Constructor(Transform transform)
        {
            _transform = transform;
        }

        public void SetParent(GameObject gameObject)
        {
            _transform.SetParent(gameObject.transform);
        }
    }

}

