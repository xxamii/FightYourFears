using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _stoneSound;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private bool _isClosed;

    public void Close()
    {
        if (!_isClosed)
        {
            _animator.SetTrigger("Close");
            _isClosed = true;
        }
    }

    public void PlayStoneSound()
    {
        _audioSource.PlayOneShot(_stoneSound);
    }
}
