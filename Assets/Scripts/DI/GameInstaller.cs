using Zenject;

public class GameInstaller : MonoInstaller
{
    public Toast ToastPrefab;

    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<LobbyManager.MembersUpdateSignal>();
        Container.DeclareSignal<LobbyManager.LobbyInviteReceivedSignal>();
        Container.BindInterfacesAndSelfTo<SteamManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<LobbyManager>().AsSingle();
        Container.BindFactory<Toast, Toast.Factory>().FromComponentInNewPrefab(ToastPrefab);
    }
}
