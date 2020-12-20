using Dungeoneer.Players;
using Dungeoneer.Managers;
using Dungeoneer.Ui;
using Steamworks;
using UnityEngine;
using Zenject;
using Dungeoneer.Ui.InGame;
using static Dungeoneer.Spells.Dungeoneer.Spells.SpellsController;

namespace Dungeoneer.DI
{
    public class GameSceneInstaller : MonoInstaller
    {
        public GameObject PlayersContainer;
        public GameObject SceneTransition;
        public GameObject PlayerPrefab;
        public override void InstallBindings()
        {
            Container.BindFactory<CSteamID, PlayerFacade, PlayerFacade.Factory>().FromSubContainerResolve().ByNewPrefabInstaller<PlayerInstaller>(PlayerPrefab).AsSingle();
            Container.Bind<GameCamera>().FromComponentOn(Camera.main.gameObject).AsSingle();
            Container.Bind<SceneTransition>().FromComponentOn(SceneTransition).AsSingle();
            Container.Bind<PlayerActionControls>().AsTransient();
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().OnInstantiated<GameManager>((ctx, manager) => manager.PlayersContainer = PlayersContainer).NonLazy();
            Container.DeclareSignal<SpellCastSignal>();
            Container.DeclareSignal<CanvasController.MenuStateChangeSignal>().OptionalSubscriber();
            Container.DeclareSignal<CanvasController.EnableMenuSignal>();
            Container.DeclareSignal<CanvasController.DisableMenuSignal>();
        }
    }
}

