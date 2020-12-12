using System;
using Dungeoneer.Managers;
using Dungeoneer.Netowrking.Packets;
using Dungeoneer.Players.Characters;
using Dungeoneer.Spells.Projectiles;
using Steamworks;
using UnityEngine;
using Zenject;
using static Dungeoneer.Managers.NetworkingManager;

namespace Dungeoneer.Spells
{
    namespace Dungeoneer.Spells
    {
        public class SpellsController : MonoBehaviour
        {
            public Rock RockProjectile;
            private SignalBus _signalBus;
            private NetworkingManager _networkingManager;
            private CharacterRenderer _renderer;
            private Rock.Factory _rockFactory;
            private CSteamID _owner;
            private PlayerActionControls.PlayerActions _controls;

            public class SpellCastSignal
            {
                public Spell Spell { get; private set; }
                public Vector2 TargetPos { get; set; }

                public SpellCastSignal(Spell spell, Vector2 targetPos)
                {
                    Spell = spell;
                    TargetPos = targetPos;
                }
            }

            [Inject]
            public void Constructor(CSteamID owner, SignalBus signalBus, NetworkingManager networkingManager, PlayerActionControls.PlayerActions controls, CharacterRenderer renderer, Rock.Factory rockFactory)
            {
                _owner = owner;
                _signalBus = signalBus;
                _networkingManager = networkingManager;
                _controls = controls;
                _renderer = renderer;
                _rockFactory = rockFactory;
            }

            private void Start()
            {
                _signalBus.Subscribe<PacketSignal<SpellPacket>>(OnSpellPacket);
            }

            private void OnSpellPacket(PacketSignal<SpellPacket> signal)
            {
                if (signal.Sender == _owner)
                {
                    if (signal.Data.Spell == Spell.Boulder)
                    {
                        if (signal.Data.Action == SpellAction.Create)
                        {
                            var projectile = _rockFactory.Create(RockProjectile);
                            projectile.transform.SetParent(gameObject.transform);
                            projectile.EndPos = Camera.main.ScreenToWorldPoint(_controls.MousePosition.ReadValue<Vector2>());
                        }
                    }
                }
            }

            private void Update()
            {
                if (_controls.CastSpell.triggered)
                {
                    var projectile = _rockFactory.Create(RockProjectile);
                    projectile.transform.SetParent(gameObject.transform);
                    projectile.EndPos = Camera.main.ScreenToWorldPoint(_controls.MousePosition.ReadValue<Vector2>());
                    _signalBus.Fire<SpellCastSignal>(new SpellCastSignal(
                        Spell.Boulder,
                        projectile.EndPos
                    ));
                    _networkingManager.SendPacketToAllPlayers<SpellPacket>(new SpellPacket()
                    {
                        Spell = Spell.Boulder,
                        Pos = projectile.EndPos,
                        Action = SpellAction.Create,
                    }, EP2PSend.k_EP2PSendReliable);
                }
            }
        }

        public enum Spell
        {
            Boulder
        }
    }
}

