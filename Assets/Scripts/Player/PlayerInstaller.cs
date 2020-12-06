using Steamworks;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
    private CSteamID _owner;

    public GameObject Renderer;

    public GameObject PhysicsBody;

    [Inject]
    public void Constructor(CSteamID owner)
    {
        _owner = owner;
    }

    public override void InstallBindings()
    {
        Container.Bind<CSteamID>().FromInstance(_owner).AsSingle();
        Container.Bind<Player>().FromComponentOnRoot().AsSingle();
        Container.Bind<Renderer>().FromComponentOn(Renderer).AsSingle();
        Container.Bind<PhysicsBody>().FromComponentOn(PhysicsBody).AsSingle();
    }
}