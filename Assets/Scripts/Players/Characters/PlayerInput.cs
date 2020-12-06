using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dugeoneer.Players.Characters
{
    public class PlayerInput : MonoBehaviour
    {
        public InputAction MousePosition;
        public InputAction MovePlayer;
        public InputAction Keystroke;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnEnable()
        {
            MovePlayer.Enable();
            MousePosition.Enable();
            Keystroke.Enable();
        }

        private void OnDisable()
        {
            MovePlayer.Disable();
            MousePosition.Disable();
            Keystroke.Disable();
        }
        // Update is called once per frame
        void Update()
        {

        }
        private void FixedUpdate()
        {

        }
    }

}
