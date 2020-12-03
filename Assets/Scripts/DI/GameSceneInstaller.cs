using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
        Container.DeclareSignal<GameManager.OpenMenuSignal>();
        Container.DeclareSignal<GameManager.ClonseMenuSignal>();
    }
}
