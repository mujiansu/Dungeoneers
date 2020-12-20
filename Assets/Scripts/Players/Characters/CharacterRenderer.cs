using UnityEngine;
using Zenject;

namespace Dungeoneer.Players.Characters
{
    public class CharacterRenderer : MonoBehaviour
    {
        private PhysicsBody _physicsBody;
        private Animator _animator;
        private Vector2 _prevPos;
        private Vector2 _newPos;
        private float _deltaTime;
        private bool _posChanged = false;
        private GameCamera _camera;
        private bool _isOwner;
        public Vector2 Pos => transform.position;

        [Inject]
        public void Constructor(bool isOwner, GameCamera camera, PhysicsBody physicsBody)
        {
            _isOwner = isOwner;
            _camera = camera;
            _physicsBody = physicsBody;
        }

        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play("Test_Idle");
        }

        // Update is called once per frame
        void Update()
        {
            _animator.Play("Test_Running");
            if (_posChanged)
            {
                _prevPos = _newPos;
                _newPos = _physicsBody.transform.position;
                _deltaTime = 0f;
                _animator.SetFloat("x_vel", _newPos.x - _prevPos.x);
                _animator.SetFloat("y_vel", _newPos.y - _prevPos.y);
                _posChanged = false;
            }
            _deltaTime += Time.deltaTime;
            var elapsedTime = _deltaTime / Time.fixedDeltaTime;
            transform.position = Vector2.Lerp(_prevPos, _newPos, elapsedTime);
            if (_isOwner)
            {
                _camera.PlayerPos = transform.position;
            }
        }

        private void FixedUpdate()
        {
            _posChanged = true;
        }
    }
}

