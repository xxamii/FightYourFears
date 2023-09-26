using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFollowPlayer : MonoBehaviour
{
    private PlayerNearTrigger _playerNearTrigger;
    private CharacterMovement _movement;

    private Transform _player;

    private bool _isFollowing;

    private void Start()
    {
        _playerNearTrigger = GetComponent<PlayerNearTrigger>();
        _movement = GetComponent<CharacterMovement>();
        _player = PlayerGlobalReference.Instance.transform;

        _playerNearTrigger.OnPlayerNear += StartFollow;
        _playerNearTrigger.OnPlayerLost += StopFollow;
    }

    private void FixedUpdate()
    {
        if (_isFollowing)
        {
            _movement.TryStartFly(_player.position);
        }
    }

    private void StartFollow()
    {
        _isFollowing = true;
        _movement.TryStartFly(_player.position);
    }

    private void StopFollow()
    {
        _isFollowing = false;
        _movement.StopFly();
    }
}
