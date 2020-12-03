using Steamworks;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public GameObject PlayersContainer;

    public Player Player;
    public override void InstallBindings()
    {
        Container.BindFactory<CSteamID, Player, Player.Factory>().FromComponentInNewPrefab(Player);
        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().OnInstantiated<GameManager>((ctx, manager) => manager.PlayersContainer = PlayersContainer).NonLazy();
        Container.DeclareSignal<GameManager.OpenMenuSignal>();
        Container.DeclareSignal<GameManager.CloseMenuSignal>();
    }
}
