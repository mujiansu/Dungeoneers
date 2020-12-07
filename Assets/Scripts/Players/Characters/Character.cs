using Dugeoneer.Netowrking.Packets;
using Dugeoneer.Players;
using Dugeoneer.Players.Characters;
using Dungeoneer.Managers;
using Dungeoneer.Steamworks;
using Steamworks;
using UnityEngine;
using Zenject;
using static Dungeoneer.Managers.NetworkingManager;

namespace Dungeoneer.Players.Characters
{
    public class Character : MonoBehaviour
    {

        public float Speed = 1f;
        private PhysicsBody _physicsBody;
        private PlayerCamera _playerCamera;
        private PlayerInput _playerInput;

        private Vector2 _moveLoc;
        private Vector2 _mouseLoc;
        private bool _playerIsMoving;

        private CSteamID _owner;

        private NetworkingManager _networkingManager;

        private SignalBus _signalBus;

        [Inject]
        public void Constructor(SignalBus signalBus, NetworkingManager networkingManager, PlayerInput playerInput, PhysicsBody physicsBody)
        {
            _networkingManager = networkingManager;
            _signalBus = signalBus;
            _playerInput = playerInput;
            _physicsBody = physicsBody;
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
            _signalBus.Subscribe<PacketSignal<CharacterPacket>>(OnCharacterPacket);
            _playerInput = GetComponent<PlayerInput>();
            _physicsBody = GetComponentInChildren<PhysicsBody>();
            _owner = GetComponentInParent<Player>().Owner;
        }


        void Update()
        {
            if (_owner == SteamHelpers.Me)
            {
                if (_playerInput.MovePlayer.ReadValue<float>() > 0)
                {
                    _moveLoc = UnityEngine.Camera.main.ScreenToWorldPoint(_playerInput.MousePosition.ReadValue<Vector2>());
                }
            }

        }

        private void FixedUpdate()
        {
            if (_owner == SteamHelpers.Me)
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
            _signalBus.Unsubscribe<PacketSignal<CharacterPacket>>(OnCharacterPacket);
        }
    }
}
