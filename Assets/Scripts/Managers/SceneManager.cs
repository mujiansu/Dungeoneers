using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Dungeoneer.Netowrking.Packets;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using static Dungeoneer.Managers.NetworkingManager;

namespace Dungeoneer.Managers
{
    public class SceneChangingManager : IInitializable
    {
        public enum Scene
        {
            MainMenu,
            Loading,
            Hub,
            A1
        }

        public class SceneLoadedSignal { }
        private int _transitionAnimationLength = 1000;
        private SignalBus _signalBus;

        private Scene _currentScene;

        private LobbyManager _lobbyManager;

        private int _membersLoading;

        private bool _changingScene = false;
        private NetworkingManager _networkingManager;

        [Inject]
        public void Constructor(SignalBus signalBus, LobbyManager lobbyManager, NetworkingManager networkingManager)
        {
            _signalBus = signalBus;
            _lobbyManager = lobbyManager;
            _networkingManager = networkingManager;
        }

        public class SceneTransitionSignal { }

        public void Initialize()
        {
            _currentScene = (Scene)Enum.Parse(typeof(Scene), SceneManager.GetActiveScene().name);
            _signalBus.Subscribe<PacketSignal<SceneChangePacket>>(OnSceneChangePacket);
        }

        private void OnSceneChangePacket(PacketSignal<SceneChangePacket> signal)
        {
            if (_lobbyManager.Lobby.Owner == signal.Sender)
            {
                ChangeScene(signal.Data.Scene, true);
            }
        }

        public async void ChangeScene(Scene scene, bool force = false)
        {
            if (_lobbyManager.Lobby.IsOwnerMe || force || !_changingScene)
            {
                if (_lobbyManager.Lobby.IsOwnerMe)
                {
                    _networkingManager.SendPacketToAllPlayers(new SceneChangePacket { Scene = scene }, EP2PSend.k_EP2PSendReliable);
                }
                _changingScene = true;
                _signalBus.Fire<SceneTransitionSignal>();
                _lobbyManager.SetLoading();
                await Task.Delay(_transitionAnimationLength);
                SceneManager.LoadScene(Scene.Loading.ToString(), LoadSceneMode.Single);
                var loader = SceneManager.LoadSceneAsync(scene.ToString(), LoadSceneMode.Single);
                loader.allowSceneActivation = false;
                _membersLoading = _lobbyManager.Lobby.Members.Count;
                while (loader.progress >= 0.9f)
                {
                    await Task.Yield();
                }
                _lobbyManager.CompleteLoading();
                while (_lobbyManager.AnyMembersLoading())
                {
                    await Task.Yield();
                }
                _changingScene = false;
            }
        }

        public void RestartScene()
        {
            ChangeScene(_currentScene);
        }
    }
}
