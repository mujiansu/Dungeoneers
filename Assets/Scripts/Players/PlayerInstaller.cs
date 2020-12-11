using Dungeoneer.Players.Characters;
using Dungeoneer.Spells.Dungeoneer.Spells;
using Dungeoneer.Spells.Projectiles;
using Dungeoneer.Steamworks;
using Steamworks;
using UnityEngine;
using Zenject;

namespace Dungeoneer.Players
{
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        private CSteamID _owner;
        public GameObject RockPrefab;
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
            Container.Bind<SpellsController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PlayerActionControls.PlayerActions>().AsSingle();
            Container.Bind<PlayerFacade>().AsSingle();
            Container.Bind<Characters.CharacterRenderer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<PhysicsBody>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Character>().FromComponentInHierarchy().AsSingle();
            Container.BindFactory<Object, Rock, Rock.Factory>().FromFactory<PrefabFactory<Rock>>();
        }
    }
}

