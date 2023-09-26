using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CharacterCollision : MonoBehaviour
    {
        [SerializeField] private Transform[] _groundCheckPoints;
        [SerializeField] private float _groundCheckDistance;
        [SerializeField] private LayerMask _groundLayer;

        public event Action OnLand;
        public event Action OnFall;

        private Transform _transform;
        private Rigidbody2D _rigidBody;

        private bool WasGrounded;

        private void Start() 
        {
            _transform = transform;
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() 
        {
            TryFall();
            TryLand();
        }

        public bool IsGrounded
        {
            get
            {
                return RayCheck(_groundCheckPoints, -_transform.up, _groundCheckDistance, _groundLayer);
            }
        }

        private bool RayCheck(Transform[] points, Vector2 direction, float distance, LayerMask layer)
        {
            foreach (Transform point in points)
            {
                if (Physics2D.Raycast(point.position, direction, distance, layer.value))
                {
                    return true;
                }
            }

            return false;
        }

        private void TryLand()
        {
            if (IsGrounded && !WasGrounded)
            {
                OnLand?.Invoke();
            }

            WasGrounded = IsGrounded;
        }

        private void TryFall()
        {
            if (!IsGrounded && _rigidBody.velocity.y < 0f)
            {
                OnFall?.Invoke();
            }
        }
    }
