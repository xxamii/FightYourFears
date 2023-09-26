using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CharacterJump : MonoBehaviour
    {
        private Rigidbody2D _rigidBody;
        private Transform _transform;
        private CharacterCollision _collision;
        private CharacterMovement _movement;

        public event Action OnJump;

        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpBufferTime;
        [SerializeField] private int _coyoteFrames;
        [SerializeField] private float _cutJumpModifier;
        private float _jumpBuffer;
        private int _coyoteTimer;

        private bool _cutJumpInput;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _collision = GetComponent<CharacterCollision>();
            _movement = GetComponent<CharacterMovement>();

            ResetJump();
        }

        private void FixedUpdate()
        {
            SetCoyote();
            TryJump();
            TryCutJump();
        }

        public void Jump()
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            ResetJump();
        }

        public void InputJump()
        {
            _jumpBuffer = Time.time + _jumpBufferTime;
        }

        public void InputCutJump()
        {
            if (!_cutJumpInput)
            {
                _cutJumpInput = true;
            }
        }

        private void TryJump()
        {
            if (Time.time <= _jumpBuffer && _coyoteTimer >= 0)
            {
                Jump();
                OnJump?.Invoke();
            }
        }

        private void TryCutJump()
        {
            if (_cutJumpInput && _rigidBody.velocity.y > 0f)
            {
                _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0f);
            }

            _cutJumpInput = false;
        }

        private void SetCoyote()
        {
            if (_collision.IsGrounded)
            {
                _coyoteTimer = _coyoteFrames;
            }
            else 
            {
                _coyoteTimer--;
            }
        }

        private void ResetJump()
        {
            _jumpBuffer = -1f;
            _coyoteTimer = -1;
        }
    }
