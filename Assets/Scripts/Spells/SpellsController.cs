using Dungeoneer.Players.Characters;
using Dungeoneer.Spells.Projectiles;
using Steamworks;
using UnityEngine;
using Zenject;

namespace Dungeoneer.Spells
{
    namespace Dungeoneer.Spells
    {
        public class SpellsController : MonoBehaviour
        {
            public Rock RockProjectile;
            private SignalBus _signalBus;
            private CharacterRenderer _renderer;
            private Rock.Factory _rockFactory;
            private CSteamID _owner;
            private PlayerActionControls.PlayerActions _controls;

            public class SpellCastSignal
            {
                public SpellElement Element { get; private set; }
                public SpellType Type { get; private set; }
                public Vector2 TargetPos { get; set; }

                public SpellCastSignal(SpellElement element, SpellType type, Vector2 targetPos)
                {
                    Element = element;
                    Type = type;
                    TargetPos = targetPos;
                }
            }

            [Inject]
            public void Constructor(CSteamID owner, SignalBus signalBus, PlayerActionControls.PlayerActions controls, CharacterRenderer renderer, Rock.Factory rockFactory)
            {
                _owner = owner;
                _signalBus = signalBus;
                _controls = controls;
                _renderer = renderer;
                _rockFactory = rockFactory;
            }

            private void Update()
            {
                if (_controls.CastSpell.triggered)
                {
                    var projectile = _rockFactory.Create(RockProjectile);
                    projectile.transform.SetParent(gameObject.transform);
                    projectile.EndPos = Camera.main.ScreenToWorldPoint(_controls.MousePosition.ReadValue<Vector2>());
                    _signalBus.Fire<SpellCastSignal>(new SpellCastSignal(
                        SpellElement.Rock,
                        SpellType.Projectile,
                        projectile.EndPos
                    ));
                }
            }
        }

        public enum SpellElement
        {
            Rock
        }

        public enum SpellType
        {
            Projectile
        }

    }
}

