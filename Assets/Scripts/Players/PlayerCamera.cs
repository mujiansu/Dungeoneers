using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dungeoneer.Players
{
    public class PlayerCamera : MonoBehaviour
    {

        private const float _zPos = -5;
        private Vector3 _desiredPos;
        private const float _speed = 7f;
        public Vector2 PlayerPos { set => _desiredPos = new Vector3(value.x, value.y, _zPos); }
        private Vector3 _prevPos;
        private Vector3 _nextPos;
        private float _timeBetweenUpdates = 0f;

        private void Update()
        {
            _timeBetweenUpdates += Time.smoothDeltaTime;
            var pos = Vector3.Lerp(_prevPos, _nextPos, _timeBetweenUpdates / Time.fixedDeltaTime);
            pos.z = _zPos;
            transform.position = pos;
        }

        private void FixedUpdate()
        {
            _timeBetweenUpdates = 0f;
            _prevPos = transform.position;
            _nextPos = Vector3.Lerp(transform.position, _desiredPos, (_speed * Time.fixedDeltaTime));
        }
    }
}

