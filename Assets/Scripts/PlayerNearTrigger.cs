using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNearTrigger : MonoBehaviour
{
    [SerializeField] private float _discoverDistance;
    [SerializeField] private LayerMask _hittable;

    public event Action OnPlayerNear;
    public event Action OnPlayerLost;

    private Transform _player;
    private Transform _transform;

    private bool _playerDiscovered;

    private void Start()
    {
        _player = PlayerGlobalReference.Instance.transform;
        _transform = transform;
    }

    private void FixedUpdate()
    {
        TryDiscover();
    }

    private void TryDiscover()
    {
        float distance = Vector2.Distance(_player.position, _transform.position);
        Vector2 directionToPlayer = _player.position - _transform.position;

        bool isPlayerNear = distance <= _discoverDistance;

        if (isPlayerNear && !_playerDiscovered)
        {
            OnPlayerNear?.Invoke();
            _playerDiscovered = true;
        }
        else if (!isPlayerNear && _playerDiscovered)
        {
            OnPlayerLost?.Invoke();
            _playerDiscovered = false;
        }
    }
}