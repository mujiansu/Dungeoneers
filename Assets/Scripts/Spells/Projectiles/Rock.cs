using System.Collections;
using Dungeoneer.Managers;
using Dungeoneer.Netowrking.Packets;
using Dungeoneer.Players;
using Dungeoneer.Players.Characters;
using Dungeoneer.Spells.Dungeoneer.Spells;
using Steamworks;
using UnityEngine;
using Zenject;
using static Dungeoneer.Managers.NetworkingManager;

namespace Dungeoneer.Spells.Projectiles
{
    public class Rock : MonoBehaviour
    {
        public EarthExplosion Explosion;
        public class Factory : PlaceholderFactory<Object, Rock> { }
        public Vector2 StartPos;
        public Vector2 EndPos;
        public float Speed;
        private bool _isOwner;
        private CSteamID _owner;
        private SignalBus _signalBus;
        private NetworkingManager _networkingManager;
        private CharacterRenderer _renderer;
        private PlayerActionControls.PlayerActions _controls;
        private GameCamera _camera;
        private float floatDistance = 1f;
        private bool shot = false;

        [Inject]
        public void Constructor(CSteamID owner, bool isOwner, SignalBus signalBus, NetworkingManager networkingManager, CharacterRenderer renderer, PlayerActionControls.PlayerActions controls, GameCamera camera)
        {
            _isOwner = isOwner;
            _owner = owner;
            _signalBus = signalBus;
            _networkingManager = networkingManager;
            _renderer = renderer;
            _controls = controls;
            _camera = camera;
        }

        void Start()
        {
            _signalBus.Subscribe<PacketSignal<SpellPacket>>(OnSpellPacketSignal);
            _controls.CastSpell.Disable();
            transform.position = _renderer.Pos + ((_camera.ScreenToWorldPoint(_controls.MousePosition.ReadValue<Vector2>()) - _renderer.Pos).normalized * floatDistance);
        }

        private void OnSpellPacketSignal(PacketSignal<SpellPacket> signal)
        {
            if (signal.Sender == _owner)
            {
                if (signal.Data.Action == SpellAction.Move)
                {
                    transform.position = signal.Data.Pos;
                }
                else if (signal.Data.Action == SpellAction.Shoot)
                {
                    StartPos = transform.position;
                    EndPos = signal.Data.Pos;
                    StartCoroutine(nameof(MoveCoroutine));
                }
            }
        }

        public IEnumerator MoveCoroutine()
        {
            shot = true;
            var velocity = Speed / Time.fixedDeltaTime;
            var totalDuration = (EndPos - StartPos).magnitude / velocity;
            var elapsed = 0f;
            var interval = 0f;
            while (interval < 1)
            {
                elapsed += Time.deltaTime;
                interval = elapsed / totalDuration;
                transform.position = Vector2.Lerp(StartPos, EndPos, interval);
                yield return null;
            }
            var explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
            explosion.transform.SetParent(transform.parent);
            Destroy(gameObject);
        }

        private void Update()
        {
            if (_isOwner && !shot)
            {
                var mousePos = _camera.ScreenToWorldPoint(_controls.MousePosition.ReadValue<Vector2>());
                transform.position = _renderer.Pos + ((mousePos - _renderer.Pos).normalized * floatDistance);
                if (_controls.CastSpell2.triggered)
                {
                    _controls.CastSpell.Enable();
                    StartPos = transform.position;
                    EndPos = mousePos;
                    StartCoroutine(nameof(MoveCoroutine));
                }
            }
        }

        private void FixedUpdate()
        {
            _networkingManager.SendPacketToAllPlayers(new SpellPacket
            {
                Spell = Spell.Boulder,
                Action = SpellAction.Shoot,
                Pos = transform.position
            });
        }
    }
}


