using Dugeoneer.Players.Characters;
using Dungeoneer.Players.Characters;
using Steamworks;
using Zenject;

namespace Dugeoneer.Players
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        private CSteamID _owner;

        [Inject]
        public void Constructor(CSteamID owner)
        {
            _owner = owner;
        }

        public override void InstallBindings()
        {
            Container.Bind<CSteamID>().FromInstance(_owner).AsSingle();
            Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Renderer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PhysicsBody>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Character>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerInput>().FromComponentInHierarchy().AsSingle();
        }
    }
}

