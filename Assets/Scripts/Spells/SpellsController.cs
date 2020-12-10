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

            public class SpellCastSignal
            {
                public SpellElement Element { get; private set; }
                public SpellType Type { get; private set; }
                public CSteamID Caster { get; private set; }
                public Vector2 CastPos { get; private set; }
                public Vector2 TargetPos { get; private set; }
                public SpellCastSignal(CSteamID caster, SpellElement element, SpellType type, Vector2 castPos, Vector2 targetPos)
                {
                    Element = element;
                    Type = type;
                    Caster = caster;
                    CastPos = castPos;
                    TargetPos = targetPos;
                }
            }

            [Inject]
            public void Constructor(SignalBus signalBus)
            {
                _signalBus = signalBus;
            }

            // Start is called before the first frame update
            void Start()
            {
                _signalBus.Subscribe<SpellCastSignal>(OnSpellCastSignal);
            }

            private void OnSpellCastSignal(SpellCastSignal signal)
            {
                if (signal.Element == SpellElement.Rock)
                {
                    if (signal.Type == SpellType.Projectile)
                    {
                        var projectile = Instantiate(RockProjectile);
                        projectile.transform.SetParent(gameObject.transform);
                        projectile.StartPos = signal.CastPos;
                        projectile.EndPos = signal.TargetPos;
                    }
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

