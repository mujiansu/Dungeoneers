using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SteamManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<LobbyManager>().AsSingle();
    }
}
