using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private bool _isAirMovement;

    private Rigidbody2D _rigidBody;
    private Transform _transform;

    private Vector2 _movingDirection;
    public float FacingDirection { get; private set; }

    public Vector2 MovingDirection
    {
        get
        {
            return _movingDirection;
        }
        set
        {
            _movingDirection = value;
            TryFlip();
        }
    }

    private Vector2 _currentAirPoint;
    private bool _isFlying;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _transform = transform;

        FacingDirection = _transform.eulerAngles.y < 90f ? 1f : -1f;
    }

    private void FixedUpdate()
    {
        if (_isAirMovement)
        {
            TryFly();
        }
        else
        {
            MoveHorizontally();
        }
    }

    public void Stop()
    {
        StopFly();
        _movingDirection = Vector2.zero;
        _rigidBody.velocity = Vector2.zero;
    }

    public void TurnOffGravity()
    {
        _rigidBody.gravityScale = 0;
    }

    public void TryStartFly(Vector2 destination)
    {
        if (_isAirMovement)
        {
            _isFlying = true;
            _currentAirPoint = destination;
        }
    }

    public void StopFly()
    {
        _isFlying = false;
        _currentAirPoint = default;
    }

    private void TryFly()
    {
        if (_isAirMovement && _isFlying)
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _currentAirPoint, _movingSpeed * Time.fixedDeltaTime);

            if (Mathf.Abs((_currentAirPoint - (Vector2)_transform.position).magnitude) <= 0.01f)
            {
                StopFly();
            }
        }
    }

    private void MoveHorizontally()
    {
        _rigidBody.velocity = new Vector2(_movingDirection.x * _movingSpeed, _rigidBody.velocity.y);
    }

    private void TryFlip()
    {
        if (_movingDirection.x != 0f && FacingDirection != _movingDirection.x)
        {
            FacingDirection = -FacingDirection;
            _transform.Rotate(0, 180, 0);
        }
    }
}
