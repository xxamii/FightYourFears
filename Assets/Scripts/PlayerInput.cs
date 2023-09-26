using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerInput : MonoBehaviour
    {
        private CharacterMovement _movement;
        private CharacterJump _jump;

        private float _directionX;
        private float _directionY;
        private bool _inputOn = true;

        private void Start()
        {
            _movement = GetComponent<CharacterMovement>();
            _jump = GetComponent<CharacterJump>();
        }

        private void Update()
        {
            if (_inputOn)
            {
                DirectionInput();
                MoveInput();
                JumpInput();
            }
        }

        public void BlockInput()
        {
            _inputOn = false;
        }

        public void UnblockInput()
        {
            _inputOn = true;
        }

        private void DirectionInput()
        {
            _directionX = Input.GetAxisRaw("Horizontal");
            _directionY = Input.GetAxisRaw("Vertical");
        }

        private void MoveInput() 
        {
            _movement.MovingDirection = new Vector2(_directionX, _directionY);
        }

        private void JumpInput()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _jump.InputJump();
            }
            else if (Input.GetKeyUp(KeyCode.Z))
            {
                _jump.InputCutJump();
            }
        }
    }
