using System.Collections;
using System.Collections.Generic;
using Dungeoneer.Players.Characters;
using UnityEngine;
using Zenject;

namespace Dungeoneer.Spells.Projectiles
{
    public class Rock : MonoBehaviour
    {
        public EarthExplosion Explosion;
        public class Factory : PlaceholderFactory<Object, Rock> { }
        public Vector2 StartPos;
        public Vector2 EndPos;
        public float Speed;
        private CharacterRenderer _renderer;
        private PlayerActionControls.PlayerActions _controls;

        private float floatDistance = 1f;
        private bool shot = false;

        [Inject]
        public void Constructor(CharacterRenderer renderer, PlayerActionControls.PlayerActions controls)
        {
            _renderer = renderer;
            _controls = controls;
        }

        void Start()
        {
            _controls.CastSpell.Disable();
            transform.position = _renderer.Pos + (((Vector2)Camera.main.ScreenToWorldPoint(_controls.MousePosition.ReadValue<Vector2>()) - _renderer.Pos).normalized * floatDistance);
        }

        public IEnumerator MoveCoroutine()
        {
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
            //Explode at end of coroutine.
        }

        private void Update()
        {
            if (!shot)
            {
                var mousePos = (Vector2)Camera.main.ScreenToWorldPoint(_controls.MousePosition.ReadValue<Vector2>());
                transform.position = _renderer.Pos + ((mousePos - _renderer.Pos).normalized * floatDistance);
                if (_controls.CastSpell2.triggered)
                {
                    _controls.CastSpell.Enable();
                    StartPos = transform.position;
                    EndPos = mousePos;
                    StartCoroutine(nameof(MoveCoroutine));
                    shot = true;
                }
            }
        }
    }
}


