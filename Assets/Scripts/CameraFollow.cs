using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _toFollow;
        [SerializeField] private float _smoothFactor;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private CameraClamp _clamp;

        private Transform _transform;

        private void Start()
        {
            _transform = transform;
        }

        private void FixedUpdate()
        {
            Follow();
        }

        public void SetPosition(Vector2 position)
        {
            float desiredX = Mathf.Clamp(position.x, _clamp.MinX, _clamp.MaxX);
            float desiredY = Mathf.Clamp(position.y, _clamp.MinY, _clamp.MaxY);
            
            Vector3 desiredPosition = new Vector3(desiredX, desiredY, -10f);
            _transform.position = desiredPosition;
        }
        
        public void ResetPosition()
        {
            SetPosition(_transform.position);
        }

        public void SetClamp(CameraClamp clamp)
        {
            _clamp = clamp;
        }

        private void Follow()
        {
            float offsetDirection = _toFollow.eulerAngles.y < 90f ? 1f : -1f;
            Vector3 offset = _offset;
            offset.x *= offsetDirection;

            float desiredX = Mathf.Clamp(_toFollow.position.x + offset.x, _clamp.MinX, _clamp.MaxX);
            float desiredY = Mathf.Clamp(_toFollow.position.y, _clamp.MinY, _clamp.MaxY);
            
            Vector3 desiredPosition = new Vector3(desiredX, desiredY, -10f);

            _transform.position = Vector3.Lerp(_transform.position, desiredPosition, _smoothFactor);
        }
    }
