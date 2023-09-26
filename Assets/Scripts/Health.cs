using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Container
{
    [SerializeField] protected float _timeBeforeDeath;
    [SerializeField] private float _safeTime;
    [SerializeField] private Collider2D[] _damageColliders;
    [SerializeField] private ParticleSystem _bloodParticles;

    [SerializeField] private AudioClip _deathSound;
    private AudioSource _audioSource;


    private CharacterMovement _movement;
    private SceneTransitions _sceneTransitions;
    private PlayerInput _input;
    [SerializeField] private GameObject _sprite;

    public event Action OnDie;
    public event Action OnHurt;
    public event Action OnSoftDie;

    private float _previousHit;
    public bool CanBeDamaged => Time.time >= _previousHit + _safeTime;
    private bool _isAlive = true;

    public bool IsAlive => _isAlive;

    protected virtual void Start()
    {
        _amount = _maxAmount;
        _movement = GetComponent<CharacterMovement>();
        _audioSource = GetComponent<AudioSource>();
        _input = GetComponent<PlayerInput>();
        _sceneTransitions = SceneTransitions.Instance;
    }

    public override void Use(float amount)
    {
        if (CanBeDamaged)
        {
            _amount -= amount;

            if (_amount <= 0f)
            {
                Die();
            }

            _previousHit = Time.time;
            OnHurt?.Invoke();
        }
    }

    public override void Add(float amount)
    {
        _amount = Mathf.Clamp(_amount + amount, 0f, _maxAmount);
    }

    public void DisableColliders()
    {
        foreach (Collider2D collider in _damageColliders)
        {
            collider.enabled = false;
        }
    }

    public void EnbleColliders()
    {
        foreach (Collider2D collider in _damageColliders)
        {
            collider.enabled = true;
        }
    }

    public virtual void SoftDie()
    {
        if (_amount > 0f)
        {
            DisableColliders();
            _isAlive = false;
            OnSoftDie?.Invoke();
        }
    }

    public void Alive()
    {
        _isAlive = true;
    }

    protected virtual void Die()
    {
        DisableColliders();
        _isAlive = false;
        _movement.Stop();
        _movement.TurnOffGravity();
        _input.BlockInput();
        _sprite.SetActive(false);
        _bloodParticles.Play();
        _audioSource.PlayOneShot(_deathSound);
        
        Invoke("Restart", 1f);
    }

    private void Restart()
    {
        _sceneTransitions.Restart();
    }
}
