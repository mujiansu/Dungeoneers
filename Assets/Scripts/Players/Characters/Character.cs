using Dungeoneer.Netowrking.Packets;
using Dungeoneer.Managers;
using Dungeoneer.Steamworks;
using Steamworks;
using UnityEngine;
using Zenject;
using static Dungeoneer.Managers.NetworkingManager;
using Dungeoneer.Ui.InGame;
using static Dungeoneer.Ui.InGame.CanvasController;
using static Dungeoneer.Spells.Dungeoneer.Spells.SpellsController;
using Dungeoneer.Spells.Dungeoneer.Spells;

namespace Dungeoneer.Players.Characters
{
    public class Character : MonoBehaviour
    {

        public float Speed = 1f;
        private PhysicsBody _physicsBody;
        private Vector2 _moveLoc;
        private PlayerActionControls.PlayerActions _controls;
        private CSteamID _owner;
        private bool _isOwner;

        private NetworkingManager _networkingManager;

        private SignalBus _signalBus;

        [Inject]
        public void Constructor(CSteamID owner, SignalBus signalBus, NetworkingManager networkingManager, PhysicsBody physicsBody, PlayerActionControls.PlayerActions controls)
        {
            _controls = controls;
            _owner = owner;
            _isOwner = _owner == SteamHelpers.Me;
            _networkingManager = networkingManager;
            _signalBus = signalBus;
            _physicsBody = physicsBody;
        }

        private void OnMenuStateChangeSignal(MenuStateChangeSignal signal)
        {
            if (signal.IsOpen) _controls.Disable();
            else _controls.Enable();
        }

        private void OnCharacterPacket(PacketSignal<CharacterPacket> packet)
        {
            if (_owner == packet.Sender)
            {
                _physicsBody.Pos = packet.Data.Pos;
            }
        }

        void Start()
        {
            if (_isOwner)
            {
                _controls.Enable();
                _signalBus.Subscribe<CanvasController.MenuStateChangeSignal>(OnMenuStateChangeSignal);
            }
            if (!_isOwner) _signalBus.Subscribe<PacketSignal<CharacterPacket>>(OnCharacterPacket);
            _physicsBody = GetComponentInChildren<PhysicsBody>();
            _moveLoc = _physicsBody.Pos;
        }


        void Update()
        {
            if (_isOwner)
            {
                if (_controls.Move.ReadValue<float>() > 0)
                {
                    _moveLoc = Camera.main.ScreenToWorldPoint(_controls.MousePosition.ReadValue<Vector2>());
                }

            }
        }

        private void FixedUpdate()
        {
            if (_isOwner)
            {
                Vector2 diff = _moveLoc - (Vector2)_physicsBody.Pos;
                var vel = diff.normalized * Speed;
                if (diff.magnitude > vel.magnitude * Time.fixedDeltaTime)
                {
                    _physicsBody.Velocity = vel;
                }
                else
                {
                    _physicsBody.Velocity = Vector2.zero;
                }
                var packet = new CharacterPacket
                {
                    Pos = _physicsBody.Pos
                };
                _networkingManager.SendPacketToAllPlayers<CharacterPacket>(packet, EP2PSend.k_EP2PSendUnreliable);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_moveLoc, 0.15f);
        }

        private void OnDestroy()
        {
            if (!_isOwner) _signalBus.Unsubscribe<PacketSignal<CharacterPacket>>(OnCharacterPacket);
        }
    }
}
