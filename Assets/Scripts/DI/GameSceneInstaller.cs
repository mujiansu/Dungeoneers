using Dungeoneer.Players;
using Dungeoneer.Managers;
using Dungeoneer.Ui;
using Steamworks;
using UnityEngine;
using Zenject;

namespace Dungeoneer.DI
{
    public class GameSceneInstaller : MonoInstaller
    {
        public GameObject PlayersContainer;

        public GameObject Camera;
        public GameObject SceneTransition;
        public Player PlayerPrefab;
        public override void InstallBindings()
        {
            Container.BindFactory<CSteamID, Player, Player.Factory>().FromSubContainerResolve().ByNewContextPrefab<PlayerInstaller>(PlayerPrefab).AsSingle();
            Container.Bind<PlayerCamera>().FromComponentOn(Camera).AsSingle();
            Container.Bind<SceneTransition>().FromComponentOn(SceneTransition).AsSingle();
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().OnInstantiated<GameManager>((ctx, manager) => manager.PlayersContainer = PlayersContainer).NonLazy();
            Container.DeclareSignal<GameManager.OpenMenuSignal>();
            Container.DeclareSignal<GameManager.CloseMenuSignal>();
        }
    }
}

