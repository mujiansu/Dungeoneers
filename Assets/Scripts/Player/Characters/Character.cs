using System;
using Steamworks;
using UnityEngine;
using Zenject;
using static NetworkingManager;

public class Character : MonoBehaviour
{

    public float Speed = 1f;
    private PhysicsBody _physicsBody;
    private PlayerCamera _playerCamera;
    private Renderer _renderer;
    private PlayerInput _playerInput;

    private Vector2 _moveLoc;

    private CSteamID _owner;

    private NetworkingManager _networkingManager;

    private SignalBus _signalBus;

    [Inject]
    public void Constructor(SignalBus signalBus, NetworkingManager networkingManager)
    {
        _networkingManager = networkingManager;
        _signalBus = signalBus;
    }

    private void OnCharacterPacket(PacketSignal<CharacterPacket> packet)
    {
        if (_owner == packet.Sender)
        {
            _physicsBody.SetPosition(packet.Data.Pos);
        }
    }

    void Start()
    {
        _signalBus.Subscribe<PacketSignal<CharacterPacket>>(OnCharacterPacket);
        _playerInput = GetComponent<PlayerInput>();
        _physicsBody = GetComponentInChildren<PhysicsBody>();
        _renderer = GetComponentInChildren<Renderer>();
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
            Vector2 diff = _moveLoc - (Vector2)_physicsBody.transform.position;
            var vel = diff.normalized * Speed;
            if (diff.magnitude > vel.magnitude * Time.fixedDeltaTime)
            {
                _physicsBody.SetVelocity(vel);
            }
            else
            {
                _physicsBody.SetVelocity(Vector2.zero);
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