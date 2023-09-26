using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : Animatable // Fucking shit code
{
    private CharacterMovement _movement;
    private CharacterJump _jump;
    private CharacterCollision _collision;

    [SerializeField] private AudioClip _stepSound;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _landSound;
    private AudioSource _audioSource;

    protected override void Start()
    {
        base.Start();

        _movement = GetComponent<CharacterMovement>();
        _jump = GetComponent<CharacterJump>();
        _collision = GetComponent<CharacterCollision>();
        _audioSource = GetComponent<AudioSource>();

        _jump.OnJump += PlayJump;
        _collision.OnLand += PlayLand;
        _collision.OnFall += PlayFall;
    }

    private void Update()
    {
        if (_movement.MovingDirection.x != 0)
        {
            PlayBoolOn("IsRunning");
        }
        else
        {
            PlayBoolOff("IsRunning");
        }
    }

    public void PlayStepSound()
    {
        _audioSource.PlayOneShot(_stepSound);
    }

    private void PlayJump()
    {
        PlayTrigger("Jump");
        _audioSource.PlayOneShot(_jumpSound);
    }

    private void PlayLand()
    {
        PlayBoolOff("IsFalling");
        PlayTrigger("Land");
        _audioSource.PlayOneShot(_landSound);
    }

    private void PlayFall()
    {
        PlayBoolOn("IsFalling");
        _animator.ResetTrigger("Jump");
    }
}
