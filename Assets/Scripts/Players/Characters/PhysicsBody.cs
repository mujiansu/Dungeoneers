using UnityEngine;

namespace Dun
namespace Dungeoneer.Players.Characters
{
    public class PhysicsBody : MonoBehaviour
    {
        private Rigidbody2D _rigidBody;
        private Collider2D _collider;
        private Vector2 _posOffset;
        public Vector2 Pos
        {
            get => _rigidBody.position + _posOffset;
            set => _rigidBody.MovePosition(value + _posOffset);
        }

        public Vector2 Velocity
        {
            get => _rigidBody.velocity;
            set => _rigidBody.velocity = value;
        }
        // Start is called before the first frame update

        void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }

        private void Start()
        {
            _rigidBody.velocity = Vector2.zero;
            _posOffset = _collider.offset;
        }
    }
}

