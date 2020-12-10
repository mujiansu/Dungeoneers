using Dungeoneer.Players.Characters;
using Dungeoneer.Steamworks;
using Steamworks;
using UnityEngine;
using Zenject;

namespace Dungeoneer.Players
{
    public class PlayerInstaller : Installer<PlayerInstaller>
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
            Container.Bind<bool>().FromInstance(_owner == SteamHelpers.Me).AsSingle();
            Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
            Container.Bind<PlayerFacade>().AsSingle();
            Container.Bind<Characters.Renderer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PhysicsBody>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Character>().FromComponentInHierarchy().AsSingle();
        }
    }
}

