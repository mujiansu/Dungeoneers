using Zenject;

public class InGameUiInstaller : MonoInstaller
{
    public Toast ToastPrefab;
    public FriendElement FriendElement;
    public override void InstallBindings()
    {
        Container.BindFactory<Toast, Toast.Factory>().FromComponentInNewPrefab(ToastPrefab);
        Container.BindFactory<FriendElement, FriendElement.Factory>().FromComponentInNewPrefab(FriendElement);
    }
}
